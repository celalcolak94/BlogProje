using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProje.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var db = new Context();
            var values = db.Comments.Include(x => x.Writer).Where(x => x.BlogId == id).ToList();
            return View(values);
        }
    }
}
