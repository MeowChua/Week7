using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Price : ViewComponent
    {
        public Price()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

