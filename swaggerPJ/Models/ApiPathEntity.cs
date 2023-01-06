using System.ComponentModel.DataAnnotations;

namespace swaggerPJ.Models
{
    [MetadataType(typeof(ApiPath))]
    public partial class ApiPath
    {
        public readonly SwaggerContext _swaggerContext;
        public ApiPath(SwaggerContext swaggerContext)
        {
            _swaggerContext = swaggerContext;
        }
        public Dictionary<string, ApiPathMethod> PathItemObject { get; set; }
    }
}
