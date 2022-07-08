using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Select : ViewComponent
    {
        public Select()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

