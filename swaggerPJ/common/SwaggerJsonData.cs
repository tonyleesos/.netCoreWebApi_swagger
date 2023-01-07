using swaggerPJ.common.Info;
using swaggerPJ.common.Path;
using swaggerPJ.common.Components;
using swaggerPJ.Models;
using System.Reflection.Metadata.Ecma335;

namespace swaggerPJ.common
{
    public class SwaggerJsonData
    {
        public string? openapi { get; set; }
        public info? info { get; set; } = null!;
        // public Paths? paths { get; set; }
        public Dictionary<string, Dictionary<string, PathMethodProperty>> paths { get; set; } = null!;
        public Component? components { get; set; }
    }
}
