using BlogProje.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Index(WriterRegisterModel writer)
		{
			if (ModelState.IsValid)
			{
				Writer w = new Writer()
				{
					WriterName = writer.WriterName,
					WriterMail = writer.WriterMail,
					WriterPassword = writer.WriterPassword,
					WriterAbout = "Deneme",
					WriterImage = "Deneme",
					WriterStatus = true
				};

				wm.TAdd(w);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				return View(writer);
			}
		}
	}
}
