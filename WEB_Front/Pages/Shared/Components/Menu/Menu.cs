using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Menu : ViewComponent
    {
        public Menu()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

