using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Breadcrumb
{
    public class Breadcrumb : ViewComponent
    {
        public Breadcrumb()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}