using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.NewsLetter
{
    public class AddNewsLetter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
