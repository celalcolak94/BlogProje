using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProje.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        [Authorize]
        public IActionResult InBox()
        {
            var values = mm.GetInboxListByWriter(Convert.ToInt32(User.FindFirstValue("sub")));
            return View(values);
        }

        [Authorize]
        public IActionResult MessageDetails(int id)
        {
            var value = mm.GetMessageIncludeSenderUser(id);
            return View(value);
        }
    }
}
