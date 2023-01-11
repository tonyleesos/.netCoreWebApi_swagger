using Newtonsoft.Json;

namespace swaggerPJ.commonV2.Path
{
    public class Items
    {
        [JsonProperty("$ref")]
        public string @ref { get; set; } = null!;
    }
}
