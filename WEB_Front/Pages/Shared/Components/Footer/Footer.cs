using Microsoft.AspNetCore.Mvc;
namespace WEB_Front.Pages.Shared.Components.Footer
{
    public class Footer : ViewComponent
    {
        public Footer()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}