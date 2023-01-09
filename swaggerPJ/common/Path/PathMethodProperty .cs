using static swaggerPJ.common.SwaggerTEST;

namespace swaggerPJ.common.Path
{
    public class PathMethodProperty
    {
        public List<string>? tags { get; set; }
        public List<Parameters>? parameters { get; set; }
        public RequestBody? requestBody { get; set; }
        public Dictionary<string, ResponseProperty>? responses { get; set; }
    }
}
