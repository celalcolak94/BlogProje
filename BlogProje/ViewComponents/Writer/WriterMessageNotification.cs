using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context db = new Context();

        public IViewComponentResult Invoke()
        {
            int writerId = db.Writers.Where(x => x.WriterName == User.Identity.Name).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);


        }
    }
}
