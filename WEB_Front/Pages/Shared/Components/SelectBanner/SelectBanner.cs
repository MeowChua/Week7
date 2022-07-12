using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class SelectBanner : ViewComponent
    {
        public SelectBanner()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

