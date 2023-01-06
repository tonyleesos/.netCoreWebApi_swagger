namespace swaggerPJ.common.Path
{
    public class Responses
    {
        // string : key ex:200 400 500...  PathMethodProperty : value  ex:PathMethodProperty => tag:array parameters:array
        public Dictionary<string, ResponseProperty>? ResponseDictionary { get; set; }
    }
}
