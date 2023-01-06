using swaggerPJ.common.Path;
using static swaggerPJ.common.SwaggerTEST;

namespace swaggerPJ.common.Components
{
    public class ComponentSchemas
    {
        // string : key ex: WeatherForecast  ComponentSchemasProperty : value ex : PathMethodProperty => get post...
        public Dictionary<string, ComponentSchemasProperty>? ComponentSchemasDictionary { get; set; }
    }
}
