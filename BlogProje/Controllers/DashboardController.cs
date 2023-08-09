using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            Context db = new Context();
            ViewBag.v1 = db.Blogs.Count();
            ViewBag.v2 = db.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.v3 = db.Categories.Count();
            return View();
        }
    }
}