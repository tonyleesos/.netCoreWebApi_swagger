namespace swaggerPJ.common.Path
{
    public class PathMethod
    {
        // string : key ex:get post...  PathMethodProperty : value ex : PathMethodProperty => tag:array parameters:array
        public Dictionary<string, PathMethodProperty>? PathDictionary { get; set; }
    }
}
