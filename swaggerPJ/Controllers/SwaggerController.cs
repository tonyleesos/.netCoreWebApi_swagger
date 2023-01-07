using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.common;
using swaggerPJ.common.Path;
using swaggerPJ.Models;
using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace swaggerPJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        private readonly SwaggerContext _swaggerContext;
        public SwaggerController(SwaggerContext swaggerContext)
        {
            _swaggerContext = swaggerContext;
        }
        [HttpGet]
        public FileContentResult JsonContentGetContent()
        {
            Content content = new Content()
            {
                 textplain = new TextPlain()
                 {
                      schema= new Schema()
                      {
                          type= "array",
                          items = new Items() { @ref = "#/components/schemas/WeatherForecast" }
                      },                   
                 },
                 textjson = new TextJson()
                 {
                     schema = new Schema()
                     {
                         type = "array",
                         items = new Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 },
                 applicationjson = new ApplicationJson()
                 {
                     schema = new Schema()
                     {
                         type = "array",
                         items = new Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 },
                 applicationjson2= new ApplicationJson() {
                     schema = new Schema()
                     {
                         type = "array",
                         items = new Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 }
            };

            Dictionary<string, ResponseProperty> responseProperty = new Dictionary<string, ResponseProperty>()
            {
                ["200"] = new ResponseProperty { description = "Success", content = content }
            };

            Dictionary<string, PathMethodProperty> pathDictionary = new Dictionary<string, PathMethodProperty>()
            {
                ["get"] = new PathMethodProperty { tags = new List<string>() { "WeatherForecast" }, responses = new Responses() {  ResponseDictionary = responseProperty }  }
            };

            // json 測試資料內容
            #pragma warning disable CS8670 // 物件或集合初始設定式意味會解除參考可能為 null 的成員。
            SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
            {
                openapi = "3.0.1",
                info = new common.Info.info()
                {
                    title="智慧所API",
                    version="1.0",                   
                },
                paths = new common.Path.Paths()
                {
                    PathDictionary = new Dictionary<string, common.Path.PathMethod>()
                    {
                        ["/WeatherForecast"] = new PathMethod(){ PathDictionary = pathDictionary }
                    }
                }

            };
 
            #pragma warning restore CS8670 // 物件或集合初始設定式意味會解除參考可能為 null 的成員。

            string? apisJson = JsonConvert.SerializeObject(swaggerJsonData);
            var fileName = "xyz.json";
            var mimeType = "application/json";
            var fileBytes = Encoding.Default.GetBytes(apisJson);
            return new FileContentResult(fileBytes, mimeType)
            {
                FileDownloadName = fileName
            };
        }
    }
}
