using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
    public class WriterAboutDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context db = new Context();

        public IViewComponentResult Invoke()
        {
            int writerId = db.Writers.Where(x => x.WriterName == User.Identity.Name).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            return View(values);
        }
        
    }
}
