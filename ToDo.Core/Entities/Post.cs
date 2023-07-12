

namespace ToDo.Core.Entities
{
    public class Post
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}
