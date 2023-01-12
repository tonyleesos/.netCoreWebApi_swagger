using Newtonsoft.Json;

namespace swaggerPJ.Models.Path
{
    public class Content
    {
        [JsonProperty("application/json")]
        public ApplicationJson applicationjson { get; set; } = null!;
    }
}
