using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.Models;
using swaggerPJ.Models.Components;
using System.Text;

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
            // dblist
            List<ApiPath> apiPathList = _swaggerContext.ApiPaths.ToList();
            List<ApiComponent> apiComponentList = _swaggerContext.ApiComponents.ToList();
            List<ApiComponentProperty> apiComponentProperty = _swaggerContext.ApiComponentProperties.ToList();
            // json 測試資料內容
            SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
            {
                openapi = "3.0.1",
                info = new Models.Info.info()
                {
                    title = "智慧所API",
                    version = "1.0",
                },
                servers = new List<Server>() {
                    new Server() { url = "https://localhost:44395" },
                    new Server() { url = "https://localhost:44396" },
                    new Server() { url = "https://localhost:44397" },
                },
                paths = new Dictionary<string, swaggerPJ.Models.Path.PathMethodProperty>(),
                components = new Component() { schemas = new Dictionary<string, ComponentSchemasProperty>()}             
            };
            // api Path
            foreach(var apiPath in apiPathList)
            {
                if(apiPath != null)
                {
                    // 包裝pathProperty 並塞DB資料
                    swaggerPJ.Models.Path.PathMethodProperty PathMethodPropertyData = new swaggerPJ.Models.Path.PathMethodProperty()
                    {
                        post = new swaggerPJ.Models.Path.Post()
                        {
                            tags = new List<string>() { apiPath.Tags.ToString() },
                            requestBody = new Models.Path.RequestBody()
                            {
                                content = new Models.Path.Content()
                                {
                                    applicationjson = new Models.Path.ApplicationJson()
                                    {
                                        schema = new Models.Path.Schema()
                                        {
                                            type = "array",
                                            items = new Models.Path.Items()
                                            {
                                                @ref = apiPath.RequestBodyItems.ToString(),
                                            }
                                        }
                                    }
                                }
                            },
                            responses = new Models.Path.Responses()
                            {                          
                                code = new Models.Path.Code()
                                {
                                    description = "Success",
                                    content = new Models.Path.Content()
                                    {
                                        applicationjson = new Models.Path.ApplicationJson()
                                        {
                                            schema = new Models.Path.Schema()
                                            {
                                                type = "array",
                                                items = new Models.Path.Items()
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
                // 包裝關聯componentProtery(撈DB資料)
                Dictionary<string, SchemaProperty> schemaPropertydata = apiComponentProperty.Where(x=>x.ApiComponentsId == apiComponent.Id)
                                     .Select(m => new { m.Name, SchemaProperty = new SchemaProperty { type = m.Type, format = m.Format } })
                                     .ToDictionary(d => d.Name, d => d.SchemaProperty);
        
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
