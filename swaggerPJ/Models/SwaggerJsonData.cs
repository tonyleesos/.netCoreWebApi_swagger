using Newtonsoft.Json;
using swaggerPJ.Models.Components;
using swaggerPJ.Models.Info;
using swaggerPJ.Models.Path;

namespace swaggerPJ.Models
{
    public class SwaggerJsonData
    {
        public string? openapi { get; set; }
        public info? info { get; set; } = null!;
        public List<Server>? servers { get; set; }
        public Dictionary<string, PathMethodProperty> paths { get; set; } = null!;
        public Component? components { get; set; }
    }
}
