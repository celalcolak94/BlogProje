using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();
            var values = db.Categories.Include(x => x.Blogs).ToList();

            return View(values);
        }
    }
}
