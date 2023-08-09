using BlogProje.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProje.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context db = new Context();

        [Authorize]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [Authorize]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {

            int writerId = Convert.ToInt32(User.FindFirstValue("sub"));
            var writervalues = wm.GetById(writerId);
            var writeredit = new WriterEditModel
            {
                WriterId = writervalues.WriterId,
                WriterName = writervalues.WriterName,
                WriterMail = writervalues.WriterMail,
                WriterAbout = writervalues.WriterAbout,
                WriterPassword = writervalues.WriterPassword
            };

            return View(writeredit);
        }

        [Authorize]
        [HttpPost]
        public IActionResult WriterEditProfile(WriterEditModel model)
        {
            var writer = new Writer();

            if (model.WriterImage != null)
            {
                var extension = Path.GetExtension(model.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                model.WriterImage.CopyTo(stream);

                writer.WriterImage = newImageName;
            }
            else
            {
                writer.WriterImage = "Boş";
            }

            if (ModelState.IsValid)
            {
                writer.WriterId = model.WriterId;
                writer.WriterName = model.WriterName;
                writer.WriterMail = model.WriterMail;
                writer.WriterAbout = model.WriterAbout;
                writer.WriterPassword = model.WriterPassword;
                writer.WriterStatus = true;

                wm.TUpdate(writer);

                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                return View(model);
            }
        }
    }
}
