using Microsoft.AspNetCore.Mvc;
namespace WEB_Front.Pages.Shared.Components.Banner
{
    public class Banner : ViewComponent
    {
        public Banner()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}