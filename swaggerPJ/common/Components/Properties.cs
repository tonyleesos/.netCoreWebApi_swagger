
namespace swaggerPJ.common.Components
{
    public class Properties
    {
        // string : key ex: 該api的property Date TemperatureC TemperatureF 
        // SchemaProperty : value  "type": "integer", "format": "int32",....
        public Dictionary<string, SchemaProperty>? ComponentSchemasDictionary { get; set; }
    }
}
