using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.Controllers
{
    public class UserHomeController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var blogs = db.Blogs.Include(x => x.Category).Include(x => x.Writer).OrderByDescending(x => x.Comments.Count()).Take(8).ToList();
            ViewBag.Last4Blog = blogs.Skip(blogs.Count() - 4).Reverse().ToList();
            return View(blogs);
        }
    }
}