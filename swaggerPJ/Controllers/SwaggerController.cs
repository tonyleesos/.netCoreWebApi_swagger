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
            #region 假資料1
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
            Dictionary<string, PathMethodProperty> pathDictionary = new Dictionary<string, PathMethodProperty>()
            {
                ["get"] = new PathMethodProperty { 
                    tags = new List<string>() { "WeatherForecast" }, 
                    responses = new Dictionary<string, ResponseProperty>() 
                    { 
                        ["200"] = new ResponseProperty (){ content = content , description = "Success" } 
                    },  
                }
            };
            #endregion

            #region 假資料2
            swaggerPJ.common.Path.Content content2 = new swaggerPJ.common.Path.Content()
            {              
                textjson = new swaggerPJ.common.Path.TextJson()
                {
                    schema = new swaggerPJ.common.Path.Schema()
                    {
                        type = "array",
                        items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/Order" }
                    },
                },
                applicationjson = new swaggerPJ.common.Path.ApplicationJson()
                {
                    schema = new swaggerPJ.common.Path.Schema()
                    {
                        type = "array",
                        items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/Order" }
                    },
                },               
            };
            Dictionary<string, PathMethodProperty> pathDictionary2 = new Dictionary<string, PathMethodProperty>()
            {
                ["post"] = new PathMethodProperty
                {
                    tags = new List<string>() { "store" },
                    requestBody = new common.Path.RequestBody
                    {
                        content = content2
                    },
                    responses = new Dictionary<string, ResponseProperty>()
                    {
                        ["200"] = new ResponseProperty() { content = content2, description = "Success" },
                        ["405"] = new ResponseProperty() { description = "Invalid input" }
                    },
                }
            };
            #endregion

            // json 測試資料內容
            SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
            {
                openapi = "3.0.1",
                info = new common.Info.info()
                {
                    title = _swaggerContext.ApiInfos.Select(x => x.Title).FirstOrDefault()?.ToString(),
                    version = _swaggerContext.ApiInfos.Select(x => x.Version).FirstOrDefault()?.ToString(),
                },
                servers = _swaggerContext.ApiServers.ToList(),
                paths = new Dictionary<string, Dictionary<string, PathMethodProperty>>()
                {
                    ["/WeatherForecast"] = pathDictionary,
                    ["/store/order"] = pathDictionary2,
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
                        },
                        ["Order"] = new ComponentSchemasProperty()
                        {
                            type = "object",
                            properties = new Dictionary<string, SchemaProperty>()
                            {
                                ["id"] = new SchemaProperty() { type = "integer", format = "int64" },
                                ["petId"] = new SchemaProperty() { type = "integer", format = "int64" },
                                ["quantity"] = new SchemaProperty() { type = "integer", format = "int32", readOnly = true },
                                ["shipDate"] = new SchemaProperty() { type = "string", format = "date-time" },
                                ["status"] = new SchemaProperty() { type = "string"}
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
