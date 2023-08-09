using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
    public class WriterNavbarProfile : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var db = new Context();
            var writer = db.Writers.FirstOrDefault(x => x.WriterName == User.Identity.Name);
            return View(writer);
        }
    }
}
