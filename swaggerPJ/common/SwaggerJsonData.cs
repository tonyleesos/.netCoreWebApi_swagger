using swaggerPJ.common.Info;
using swaggerPJ.common.Path;
using swaggerPJ.common.Components;
using swaggerPJ.Models;
using System.Reflection.Metadata.Ecma335;

namespace swaggerPJ.common
{
    public class SwaggerJsonData
    {
        public string? openApi { get; set; }
        public info? info { get; set; }
        public Paths? paths { get; set; }
        public Component? components { get; set; }
    }
}
