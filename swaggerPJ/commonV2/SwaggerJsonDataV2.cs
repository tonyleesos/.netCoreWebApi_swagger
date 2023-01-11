using Newtonsoft.Json;
using swaggerPJ.common.Components;
using swaggerPJ.common.Info;
using swaggerPJ.commonV2.Path;

namespace swaggerPJ.commonV2
{
    public class SwaggerJsonDataV2
    {
        public string? openapi { get; set; }
        public info? info { get; set; } = null!;
        public List<Server>? servers { get; set; }
        public Dictionary<string, swaggerPJ.commonV2.Path.PathMethodProperty> paths { get; set; } = null!;
        public Component? components { get; set; }
    }
}
