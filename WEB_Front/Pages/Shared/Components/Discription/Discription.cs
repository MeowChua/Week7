using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Discription : ViewComponent
    {
        public Discription()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

