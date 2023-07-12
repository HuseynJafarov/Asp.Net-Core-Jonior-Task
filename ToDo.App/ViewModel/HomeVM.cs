using ToDo.App.Helpers;
using ToDo.Core.Entities;

namespace ToDo.App.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Album>? Albums { get; set; }
        public Paginate<Post> Paginate { get; set; }
    }
}
