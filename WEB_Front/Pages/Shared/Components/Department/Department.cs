using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_Front.Pages.Shared.Components.Menu
{
    public class Department : ViewComponent
    {
        public Department()
        {
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}