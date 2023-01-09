using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.common;
using swaggerPJ.common.Components;
using swaggerPJ.common.Path;
using swaggerPJ.common.Servers;
using swaggerPJ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static swaggerPJ.common.SwaggerTEST;
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
            swaggerPJ.common.Path.Content content = new swaggerPJ.common.Path.Content()
            {
                 textplain = new swaggerPJ.common.Path.TextPlain()
                 {
                      schema= new swaggerPJ.common.Path.Schema()
                      {
                          type= "array",
                          items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/WeatherForecast" }
                      },                   
                 },
                 textjson = new swaggerPJ.common.Path.TextJson()
                 {
                     schema = new swaggerPJ.common.Path.Schema()
                     {
                         type = "array",
                         items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 },
                 applicationjson = new swaggerPJ.common.Path.ApplicationJson()
                 {
                     schema = new swaggerPJ.common.Path.Schema()
                     {
                         type = "array",
                         items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 },
                 applicationjson2= new swaggerPJ.common.Path.ApplicationJson() {
                     schema = new swaggerPJ.common.Path.Schema()
                     {
                         type = "array",
                         items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/WeatherForecast" }
                     },
                 }
            };

            Dictionary<string, ResponseProperty> responseProperty = new Dictionary<string, ResponseProperty>()
            {
                ["200"] = new ResponseProperty { description = "Success", content = content }
            };

            Dictionary<string, PathMethodProperty> pathDictionary = new Dictionary<string, PathMethodProperty>()
            {
                ["get"] = new PathMethodProperty { 
                    tags = new List<string>() { "WeatherForecast" }, 
                    responses = new Dictionary<string, ResponseProperty>() 
                    { 
                        ["200"] = new ResponseProperty (){ content = content , description = "Success" } 
                    }  
                }
            };

            // json 測試資料內容
            SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
            {
                openapi = "3.0.1",
                info = new common.Info.info()
                {
                    title = "智慧所API",
                    version = "1.0",
                },
                servers = new List<Server>() 
                {
                   new Server(){url = "https://localhost:44395" },
                   new Server(){url = "https://localhost:44396" },
                   new Server(){url = "https://localhost:44397" },
                },
                paths = new Dictionary<string, Dictionary<string, PathMethodProperty>>()
                {
                    ["/WeatherForecast"] = pathDictionary
                },
                components = new common.Components.Component
                {
                    schemas = new Dictionary<string, ComponentSchemasProperty>()
                    {
                        ["WeatherForecast"] = new ComponentSchemasProperty() { 
                            type = "object",
                            properties = new Dictionary<string, SchemaProperty>()
                            {
                                ["data"] = new SchemaProperty() { type = "string",format= "date-time" },
                                ["temperatureC"] = new SchemaProperty() { type = "integer", format = "int32" },
                                ["temperatureF"] = new SchemaProperty() { type = "integer", format = "int32",readOnly = true },
                                ["summary"] = new SchemaProperty() { type = "string",nullable = true }
                            }, 
                            additionalProperties = false 
                        }
                    }
                }
            };


            string? apisJson = JsonConvert.SerializeObject(swaggerJsonData, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
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
