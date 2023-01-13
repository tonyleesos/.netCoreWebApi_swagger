using swaggerPJ.common.Servers;
using System.Reflection.Metadata.Ecma335;
using swaggerPJ.Models;
using swaggerPJ.Models.Components;
using swaggerPJ.common.Info;
using swaggerPJ.common.Path;

namespace swaggerPJ.common
{
    public class SwaggerJsonData
    {       
        public string? openapi { get; set; }
        public info? info { get; set; } = null!;
        public List<Server>? servers { get; set; }
        public Dictionary<string, Dictionary<string, PathMethodProperty>> paths { get; set; } = null!;
        public Component? components { get; set; }
    }
}
