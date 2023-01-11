using Newtonsoft.Json;

namespace swaggerPJ.commonV2.Path
{
    public class Content
    {
        [JsonProperty("application/json")]
        public ApplicationJson applicationjson { get; set; } = null!;
    }
}
