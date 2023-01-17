using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.OpenApi.Models;
using swaggerPJ.Models;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    //�쥻�O JsonNamingPolicy.CamelCase�A�j���Y��r��p�g�A�ڰ��n������ˡA�]��null
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //���\�򥻩ԤB�^��Τ�������r������r��
    options.JsonSerializerOptions.Encoder =
        JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs);
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
    //�쥻�O JsonNamingPolicy.CamelCase�A�j���Y��r��p�g�A�ڰ��n������ˡA�]��null
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //���\�򥻩ԤB�^��Τ�������r������r��
    options.JsonSerializerOptions.Encoder =
        JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs);
});
builder.Services.AddRazorPages().AddJsonOptions(options =>
{
    //�쥻�O JsonNamingPolicy.CamelCase�A�j���Y��r��p�g�A�ڰ��n������ˡA�]��null
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //���\�򥻩ԤB�^��Τ�������r������r��
    options.JsonSerializerOptions.Encoder =
        JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs);
});

//dbContext ConnectString use in appsettings.json
builder.Services.AddDbContext<SwaggerContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region swaggerDoc AddSwaggerGen
// swaggerDoc
builder.Services.AddSwaggerGen(c =>
{   
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.CustomSchemaIds(x => x.FullName);
});
#endregion

var app = builder.Build();

#region swaggerDoc
// swaggerDoc
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger-editor-doc/{documentName}/swagger.json";
});
app.UseReDoc(c =>
{
    c.RoutePrefix = "swagger-editor-doc";
});

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swaggerFile/swagger.json", "My API V1"); });
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "swaggerFile")),
    RequestPath = "/swaggerFile"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
