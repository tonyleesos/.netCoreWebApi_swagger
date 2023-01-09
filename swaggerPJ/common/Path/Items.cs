using Newtonsoft.Json;

namespace swaggerPJ.common.Path
{
    public class Items
    {
        public string? type { get; set; }

        [JsonProperty("$ref")]
        public string? @ref { get; set; }
    }
}
