using swaggerPJ.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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

//dbContext
builder.Services.AddDbContext<SwaggerContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
