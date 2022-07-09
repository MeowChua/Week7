using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Blog : ViewComponent
    {
        public Blog()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}