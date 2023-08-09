
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();
            var values = db.Blogs.Include(x => x.Category).ToList();
            values = values.Skip(values.Count() - 10).OrderByDescending(x => x.BlogCreateDate).ToList();
            return View(values);
        }
    }
}
