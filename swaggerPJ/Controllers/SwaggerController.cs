using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.common;
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
            // json 資料內容
            #pragma warning disable CS8670 // 物件或集合初始設定式意味會解除參考可能為 null 的成員。
            SwaggerJsonData swaggerJsonData = new SwaggerJsonData()
            {
                openApi = "3.0.1",
                
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
