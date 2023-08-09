using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();

            var values = db.Blogs.OrderByDescending(x => x.BlogCreateDate).ToList();
            values = values.Take(3).ToList();
            return View(values);
        }
    }
}
