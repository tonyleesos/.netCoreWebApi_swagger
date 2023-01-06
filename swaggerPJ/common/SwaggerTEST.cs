using Newtonsoft.Json;

namespace swaggerPJ.common
{
    public class SwaggerTEST
    {
        public class _200
        {
            public string description { get; set; }
            public Content content { get; set; }
        }

        public class ApiValues
        {
            public Get get { get; set; }
            public Post post { get; set; }
        }

        public class ApiValuesId
        {
            public Get get { get; set; }
            public Put put { get; set; }
            public Delete delete { get; set; }
        }

        public class ApplicationJson
        {
            public Schema schema { get; set; }
        }

        public class ApplicationJson3
        {
            public Schema schema { get; set; }
        }

        public class Components
        {
            public Schemas schemas { get; set; }
        }

        public class Content
        {
            [JsonProperty("text/plain")]
            public TextPlain textplain { get; set; }

            [JsonProperty("application/json")]
            public ApplicationJson applicationjson { get; set; }

            [JsonProperty("text/json")]
            public TextJson textjson { get; set; }

            [JsonProperty("application/*+json")]
            public ApplicationJson? applicationjson2 { get; set; }
        }

        public class Date
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Delete
        {
            public List<string> tags { get; set; }
            public List<Parameter> parameters { get; set; }
            public Responses responses { get; set; }
        }

        public class Get
        {
            public List<string> tags { get; set; }
            public Responses responses { get; set; }
            public List<Parameter> parameters { get; set; }
            public string operationId { get; set; }
        }

        public class Info
        {
            public string title { get; set; }
            public string version { get; set; }
        }

        public class Items
        {
            public string type { get; set; }

            [JsonProperty("$ref")]
            public string @ref { get; set; }
        }

        public class Parameter
        {
            public string name { get; set; }
            public string @in { get; set; }
            public bool required { get; set; }
            public Schema schema { get; set; }
        }

        public class Paths
        {
            [JsonProperty("/api/Values")]
            public ApiValues apiValues { get; set; }

            [JsonProperty("/api/Values/{id}")]
            public ApiValuesId apiValuesid { get; set; }

            [JsonProperty("/WeatherForecast")]
            public WeatherForecast WeatherForecast { get; set; }
        }

        public class Post
        {
            public List<string> tags { get; set; }
            public RequestBody requestBody { get; set; }
            public Responses responses { get; set; }
        }

        public class Properties
        {
            public Date Date { get; set; }
            public TemperatureC TemperatureC { get; set; }
            public TemperatureF TemperatureF { get; set; }
            public Summary Summary { get; set; }
        }

        public class Put
        {
            public List<string> tags { get; set; }
            public List<Parameter> parameters { get; set; }
            public RequestBody requestBody { get; set; }
            public Responses responses { get; set; }
        }

        public class RequestBody
        {
            public Content content { get; set; }
        }

        public class Responses
        {
            [JsonProperty("200")]
            public _200 _200 { get; set; }
        }

        public class Root
        {
            public string openapi { get; set; }
            public Info info { get; set; }
            public Paths paths { get; set; }
            public Components components { get; set; }
        }

        public class Schema
        {
            public string type { get; set; }
            public Items items { get; set; }
            public string format { get; set; }
        }

        public class Schemas
        {
            public WeatherForecast WeatherForecast { get; set; }
        }

        public class Summary
        {
            public string type { get; set; }
            public bool nullable { get; set; }
        }

        public class TemperatureC
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TemperatureF
        {
            public string type { get; set; }
            public string format { get; set; }
            public bool readOnly { get; set; }
        }

        public class TextJson
        {
            public Schema schema { get; set; }
        }

        public class TextPlain
        {
            public Schema schema { get; set; }
        }

        public class WeatherForecast
        {
            public Get get { get; set; }
        }

        public class WeatherForecast2
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public bool additionalProperties { get; set; }
        }
    }
}
