using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Comment
{
    public class CommentAdd : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentRepository());
            using var db = new Context();

            var writers = db.Writers.Where(x => x.WriterName == User.Identity.Name).ToList();

            ViewBag.BlogId = id;

            return View(writers);
        }
    }
}
