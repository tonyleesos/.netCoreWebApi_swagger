using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using swaggerPJ.common;
using swaggerPJ.common.Components;
using swaggerPJ.common.Path;
using swaggerPJ.common.Servers;
using swaggerPJ.commonV2;
using swaggerPJ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

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
        //[HttpGet]
        //public FileContentResult JsonContentGetContent()
        //{
        //    #region 假資料1
        //    swaggerPJ.common.Path.Content content = new swaggerPJ.common.Path.Content()
        //    {              
        //        applicationjson = new swaggerPJ.common.Path.ApplicationJson()
        //        {
        //            schema = new swaggerPJ.common.Path.Schema()
        //            {
        //                type = "array",
        //                items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/WeatherForecast" }
        //            },
        //        },
        //    };
        //    // var apiPaths = _swaggerContext.ApiPaths.ToList();
        //    Dictionary<string, PathMethodProperty> pathDictionary = new Dictionary<string, PathMethodProperty>()
        //    {
        //        ["get"] = new PathMethodProperty
        //        {
        //            tags = new List<string>() { "WeatherForecast" },
        //            responses = new Dictionary<string, ResponseProperty>()
        //            {
        //                ["200"] = new ResponseProperty() { content = content, description = "Success" }
        //            },
        //        }
        //    };
        //    //foreach (var apiPath in apiPaths)
        //    //{
        //    //    pathDictionary.Add(apiPath.Method, apiPath);
        //    //}
        //    #endregion

        //    #region 假資料2
        //    swaggerPJ.common.Path.Content content2 = new swaggerPJ.common.Path.Content()
        //    {              
        //        applicationjson = new swaggerPJ.common.Path.ApplicationJson()
        //        {
        //            schema = new swaggerPJ.common.Path.Schema()
        //            {
        //                type = "array",
        //                items = new swaggerPJ.common.Path.Items() { @ref = "#/components/schemas/Order" }
        //            },
        //        },
        //    };
        //    Dictionary<string, PathMethodProperty> pathDictionary2 = new Dictionary<string, PathMethodProperty>()
        //    {
        //        ["post"] = new PathMethodProperty
        //        {
        //            tags = new List<string>() { "store" },
        //            requestBody = new common.Path.RequestBody
        //            {
        //                content = content2
        //            },
        //            responses = new Dictionary<string, ResponseProperty>()
        //            {
        //                ["200"] = new ResponseProperty() { content = content2, description = "Success" },                        
        //            },
        //        }
        //    };
        //    #endregion
        //    // json 測試資料內容
        //    SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
        //    {
        //        openapi = "3.0.1",
        //        info = new common.Info.info()
        //        {
        //            title = "智慧所API",
        //            version = "1.0",
        //        },
        //        servers = new List<Server>() {
        //            new Server() { url = "https://localhost:44395" },
        //            new Server() { url = "https://localhost:44396" },
        //            new Server() { url = "https://localhost:44397" },
        //        },
        //        paths = new Dictionary<string, Dictionary<string, PathMethodProperty>>()
        //        {
        //            ["/WeatherForecast"] = pathDictionary,
        //            ["/store/order"] = pathDictionary2,
        //        },

        //        components = new common.Components.Component
        //        {
        //            schemas = new Dictionary<string, ComponentSchemasProperty>()
        //            {
        //                ["WeatherForecast"] = new ComponentSchemasProperty()
        //                {
        //                    type = "object",
        //                    properties = new Dictionary<string, SchemaProperty>()
        //                    {
        //                        ["data"] = new SchemaProperty() { type = "string", format = "date-time" },
        //                        ["temperatureC"] = new SchemaProperty() { type = "integer", format = "int32" },
        //                        ["temperatureF"] = new SchemaProperty() { type = "integer", format = "int32", readOnly = true },
        //                        ["summary"] = new SchemaProperty() { type = "string", nullable = true }
        //                    },
        //                    additionalProperties = false
        //                },
        //                ["Order"] = new ComponentSchemasProperty()
        //                {
        //                    type = "object",
        //                    properties = new Dictionary<string, SchemaProperty>()
        //                    {
        //                        ["id"] = new SchemaProperty() { type = "integer", format = "int64" },
        //                        ["petId"] = new SchemaProperty() { type = "integer", format = "int64" },
        //                        ["quantity"] = new SchemaProperty() { type = "integer", format = "int32", readOnly = true },
        //                        ["shipDate"] = new SchemaProperty() { type = "string", format = "date-time" },
        //                        ["status"] = new SchemaProperty() { type = "string" }
        //                    },
        //                    additionalProperties = false
        //                }
        //            }
        //        }
        //    };

        //    string? apisJson = JsonConvert.SerializeObject(swaggerJsonData, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore
        //    });
        //    var fileName = "xyz.json";
        //    var mimeType = "application/json";
        //    var fileBytes = Encoding.Default.GetBytes(apisJson);
        //    return new FileContentResult(fileBytes, mimeType)
        //    {
        //        FileDownloadName = fileName
        //    };
        //}

        [HttpGet]
        public FileContentResult JsonContentGetContentV2()
        {
            // dblist
            List<ApiPath> apiPathList = _swaggerContext.ApiPaths.ToList();
            List<ApiComponent> apiComponentList = _swaggerContext.ApiComponents.ToList();
            List<ApiComponentProperty> apiComponentProperty = _swaggerContext.ApiComponentProperties.ToList();
            // json 測試資料內容
            SwaggerJsonDataV2 swaggerJsonData = new SwaggerJsonDataV2()
            {
                openapi = "3.0.1",
                info = new common.Info.info()
                {
                    title = "智慧所API",
                    version = "1.0",
                },
                servers = new List<Server>() {
                    new Server() { url = "https://localhost:44395" },
                    new Server() { url = "https://localhost:44396" },
                    new Server() { url = "https://localhost:44397" },
                },
                paths = new Dictionary<string, swaggerPJ.commonV2.Path.PathMethodProperty>(),
                components = new Component() { schemas = new Dictionary<string, ComponentSchemasProperty>()}             
            };
            // api Path
            foreach(var apiPath in apiPathList)
            {
                if(apiPath != null)
                {
                    // 包裝pathProperty 並塞DB資料
                    swaggerPJ.commonV2.Path.PathMethodProperty PathMethodPropertyData = new swaggerPJ.commonV2.Path.PathMethodProperty()
                    {
                        post = new swaggerPJ.commonV2.Path.Post()
                        {
                            tags = new List<string>() { apiPath.Tags.ToString() },
                            requestBody = new commonV2.Path.RequestBody()
                            {
                                content = new commonV2.Path.Content()
                                {
                                    applicationjson = new commonV2.Path.ApplicationJson()
                                    {
                                        schema = new commonV2.Path.Schema()
                                        {
                                            type = "array",
                                            items = new commonV2.Path.Items()
                                            {
                                                @ref = apiPath.RequestBodyItems.ToString(),
                                            }
                                        }
                                    }
                                }
                            },
                            responses = new commonV2.Path.Responses()
                            {                          
                                code = new commonV2.Path.Code()
                                {
                                    description = "Success",
                                    content = new commonV2.Path.Content()
                                    {
                                        applicationjson = new commonV2.Path.ApplicationJson()
                                        {
                                            schema = new commonV2.Path.Schema()
                                            {
                                                type = "array",
                                                items = new commonV2.Path.Items()
                                                {
                                                    @ref = apiPath.ResponseItems.ToString(),
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    };
                    // push pathProperty
                    swaggerJsonData.paths.TryAdd(apiPath.Name.ToString(), PathMethodPropertyData);
                }
            }                    
            // api Component
            foreach (var apiComponent in apiComponentList)
            {
                Dictionary<string, SchemaProperty> schemaPropertydata = apiComponentProperty.Where(x=>x.ApiComponentsId == apiComponent.Id)
                                     .Select(m => new { m.Name, SchemaProperty = new SchemaProperty { type = m.Type, format = m.Format } })
                                     .ToDictionary(d => d.Name, d => d.SchemaProperty);
                // 包裝關聯componentProtery(撈DB資料)
                //Dictionary<string, SchemaProperty> schemaPropertydata = apiComponent.ApiComponentProperties
                //                                .Select(m => new { m.Name, SchemaProperty = new SchemaProperty { type = m.Type,format = m.Format } })
                //                                .ToDictionary(d => d.Name, d => d.SchemaProperty);               
                // 撈DB資料並初始化
                ComponentSchemasProperty componentSchemasProperty = new ComponentSchemasProperty()
                {
                    type = apiComponent.Type.ToString(), 
                    properties = new Dictionary<string, SchemaProperty>(),
                    additionalProperties = false
                };
                // push 裡面內層
                foreach(var item in schemaPropertydata)
                {
                    componentSchemasProperty.properties.TryAdd(item.Key, item.Value);
                }
                // push 最外層
                swaggerJsonData.components.schemas.TryAdd(apiComponent.Name.ToString(), componentSchemasProperty);
            }

            string? apisJson = JsonConvert.SerializeObject(swaggerJsonData, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var dateTime = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
            var fileName = dateTime + ".json";
            var mimeType = "application/json";
            var fileBytes = Encoding.Default.GetBytes(apisJson);
            return new FileContentResult(fileBytes, mimeType)
            {
                FileDownloadName = fileName
            };
        }
    }
}
