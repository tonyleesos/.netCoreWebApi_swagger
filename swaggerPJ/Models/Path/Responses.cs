using Newtonsoft.Json;

namespace swaggerPJ.Models.Path
{
    public class Responses
    {
        [JsonProperty("200")]
        public Code code { get; set; } = null!;
    }
}
