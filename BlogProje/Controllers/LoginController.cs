using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProje.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, datavalue.WriterName),
                    new Claim(ClaimTypes.Email, datavalue.WriterMail),
                    new Claim("sub", datavalue.WriterId.ToString())
                };

                var useridentity = new ClaimsIdentity(claims, "a");
                var principal = new ClaimsPrincipal(useridentity);

                HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Şifre yanlış.");
                return View(writer);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Blog");
        }
    }
}
