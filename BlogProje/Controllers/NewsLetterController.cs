using BlogProje.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BlogProje.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetterModel model)
        {
            if (ModelState.IsValid)
            {
                var newsLetter = new NewsLetter
                {
                    Mail = model.Mail,
                    MailStatus = true
                };

                nm.AddNewsLetter(newsLetter);

                return Json(new { success = true, message = "İşlem başarılı" });
            }
            else
            {
                return Json(new { success = false });
            }

        }

    }
}
