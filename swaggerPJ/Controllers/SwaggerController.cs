using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using swaggerPJ.Models;

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
        public void JsonContentGetContent()
        {
           
        }
    }
}
