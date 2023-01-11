namespace swaggerPJ.common.Components
{
    public class ComponentSchemasProperty
    {
        public string? type { get; set; }
        public Dictionary<string, SchemaProperty>? properties { get; set; }
        public bool? additionalProperties { get; set; }
    }
}
