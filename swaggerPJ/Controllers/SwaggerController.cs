using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.Models;
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
            Apis apis = new Apis
            {
                Title = "智慧影像平台",
                Description = "智聯所內部專用",
                Version = "v1",
            };
            string? apisJson = JsonConvert.SerializeObject(apis);
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
