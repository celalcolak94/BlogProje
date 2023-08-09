using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        [HttpPost]
        public JsonResult PartialAddComment(Comment comment)
        {
            using var db = new Context();

            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogScore = 0;
            cm.CommentAdd(comment);

            return Json(new { success = true, message = "İşlem başarılı" });
        }
    }
}
