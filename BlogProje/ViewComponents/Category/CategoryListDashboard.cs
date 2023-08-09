using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();
            var values = db.Categories.Include(x => x.Blogs).ToList();

            int blogsCount = db.Blogs.Count();
            ViewBag.BlogsCount = blogsCount;

            return View(values);
        }
    }
}
