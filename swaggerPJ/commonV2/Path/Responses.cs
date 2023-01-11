using Newtonsoft.Json;

namespace swaggerPJ.commonV2.Path
{
    public class Responses
    {
        [JsonProperty("200")]
        public Code code { get; set; } = null!;
    }
}
