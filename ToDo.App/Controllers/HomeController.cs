using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDo.App.Helpers;
using ToDo.App.ViewModel;
using ToDo.Core.Data;
using ToDo.Core.Entities;

namespace ToDo.App.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1,int take =10)
        {

            List<Post> posts = await _context.Posts.Skip((page * take) - take)
                .Take(take).ToListAsync();
            IEnumerable<Album> albums = await _context.Albums.ToListAsync();
            int count = await GetPageCount(take);


            Paginate<Post> paginate = new (posts,page ,count);
            HomeVM vm = new HomeVM()
            {
                Posts = posts,
                Albums = albums,
                Paginate = paginate
            };

            return View(vm);
        }

        public IActionResult Search(string search)
        {
            List<Post> searchPost = _context.Posts.Where(s=> s.title.Trim().Contains(search.Trim())).ToList();
            return PartialView("_Search",searchPost);
        }

        public async Task<IActionResult> AddJsonToDatabase()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Albums ON");

                var url = "https://jsonplaceholder.typicode.com/albums";
                var entities = await ToDo.Helpers.ConvertJsonToObject.JsonDeserialize<List<Album>>(url);

                foreach (var entity in entities)
                {
                    _context.Albums.Add(entity);
                }
                await _context.SaveChangesAsync();

                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Albums OFF");
                _context.Database.CloseConnection();
            }
            catch (Exception)
            {
                return BadRequest("Check Method");
            }

            return RedirectToAction(nameof(Index));
        }


        private async Task<int> GetPageCount(int take)
        {
            int postCount = await _context.Posts.CountAsync();

            return (int)Math.Ceiling((decimal)postCount / take);
        }

    }
}