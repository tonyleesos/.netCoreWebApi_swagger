using swaggerPJ.Models;
using System.Reflection.Metadata.Ecma335;

namespace swaggerPJ.common
{
    public class SwaggerJsonData
    {
        public string? openApi { get; set; }
        public Apis? ApisData { get; set; }
        public ApiPath? ApiPathData { get; set; }
        public ApiComponent? ApiComponentData { get; set; }
        public ApiServer? ApiServerData { get; set; }
    }
}
