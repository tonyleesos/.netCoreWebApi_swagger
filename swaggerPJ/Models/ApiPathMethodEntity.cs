using System.ComponentModel.DataAnnotations;

namespace swaggerPJ.Models
{
    [MetadataType(typeof(ApiPathMethod))]
    public partial class ApiPathMethod
    {
        public readonly SwaggerContext _swaggerContext;
        public ApiPathMethod(SwaggerContext swaggerContext)
        {
            _swaggerContext = swaggerContext;
        }
        public Dictionary<string, string> MethodItemObject { get; set; }
    }
}
