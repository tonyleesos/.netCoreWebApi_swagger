using Newtonsoft.Json;

namespace swaggerPJ.common.Path
{
    public class Content
    {
        [JsonProperty("text/plain")]
        public TextPlain? textplain { get; set; }

        [JsonProperty("application/json")]
        public ApplicationJson? applicationjson { get; set; }

        [JsonProperty("text/json")]
        public TextJson? textjson { get; set; }

        [JsonProperty("application/*+json")]
        public ApplicationJson? applicationjson2 { get; set; }
    }
}
