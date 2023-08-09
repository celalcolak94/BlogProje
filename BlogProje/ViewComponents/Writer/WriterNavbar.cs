using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
    public class WriterNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();

            var writerName = User.Identity.Name;
            var writer = db.Writers.FirstOrDefault(x => x.WriterName == writerName);

            return View(writer);
        }
    }
}
