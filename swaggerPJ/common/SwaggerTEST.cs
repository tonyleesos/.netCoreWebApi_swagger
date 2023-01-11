// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class _200
{
    public string description { get; set; } = null!;
    public Content content { get; set; } = null!;
}

public class ApplicationJson
{
    public Schema schema { get; set; } = null!;
}

public class Components
{
    public Schemas schemas { get; set; } = null!;
}

public class Content
{
    [JsonProperty("application/json")]
    public ApplicationJson applicationjson { get; set; } = null!;
}

public class Data
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class Id
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class Info
{
    public string title { get; set; } = null!;
    public string version { get; set; } = null!;
}

public class Items
{
    [JsonProperty("$ref")]
    public string @ref { get; set; } = null!;
}

public class Order
{
    public string type { get; set; } = null!;
    public Properties properties { get; set; } = null!;
    public bool additionalProperties { get; set; }
}

public class Paths
{
    [JsonProperty("/WeatherForecast")]
    public WeatherForecast WeatherForecast { get; set; } = null!;

    [JsonProperty("/store/order")]
    public StoreOrder storeorder { get; set; } = null!;

    [JsonProperty("/store/costom")]
    public StoreCostom storecostom { get; set; } = null!;
}

public class PetId
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class Post
{
    public List<string> tags { get; set; } = null!;
    public RequestBody requestBody { get; set; } = null!;
    public Responses responses { get; set; } = null!;
}

public class Properties
{
    public Data data { get; set; } = null!;
    public TemperatureC temperatureC { get; set; } = null!;
    public TemperatureF temperatureF { get; set; } = null!;
    public Summary summary { get; set; } = null!;
    public Id id { get; set; } = null!;
    public PetId petId { get; set; } = null!;
    public Quantity quantity { get; set; } = null!;
    public ShipDate shipDate { get; set; } = null!;
    public Status status { get; set; } = null!;
}

public class Quantity
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class RequestBody
{
    public Content content { get; set; } = null!;
}

public class Responses
{
    [JsonProperty("200")]
    public _200 _200 { get; set; } = null!;
}

public class Root
{
    public string openapi { get; set; } = null!;
    public Info info { get; set; } = null!;
    public List<Server> servers { get; set; } = null!;
    public Paths paths { get; set; } = null!;
    public Components components { get; set; } = null!;
}

public class Schema
{
    public string type { get; set; } = null!;
    public Items items { get; set; } = null!;
}

public class Schemas
{
    public WeatherForecast WeatherForecast { get; set; } = null!;
    public Order Order { get; set; } = null!;
}

public class Server
{
    public string url { get; set; } = null!;
}

public class ShipDate
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class Status
{
    public string type { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class StoreCostom
{
    public Post post { get; set; } = null!;
}

public class StoreOrder
{
    public Post post { get; set; } = null!;
}

public class Summary
{
    public string type { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class TemperatureC
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class TemperatureF
{
    public string type { get; set; } = null!;
    public string format { get; set; } = null!;
    public bool readOnly { get; set; }
    public bool nullable { get; set; }
}

public class WeatherForecast
{
    public Post post { get; set; } = null!;
}

public class WeatherForecast2
{
    public string type { get; set; } = null!;
    public Properties properties { get; set; } = null!;
    public bool additionalProperties { get; set; }
}

