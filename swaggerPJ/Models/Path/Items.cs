using Newtonsoft.Json;

namespace swaggerPJ.Models.Path
{
    public class Items
    {
        [JsonProperty("$ref")]
        public string @ref { get; set; } = null!;
    }
}
