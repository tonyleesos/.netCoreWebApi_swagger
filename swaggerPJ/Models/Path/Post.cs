namespace swaggerPJ.Models.Path
{
    public class Post
    {
        public List<string> tags { get; set; } = null!;
        public RequestBody requestBody { get; set; } = null!;
        public Responses responses { get; set; } = null!;
    }
}
