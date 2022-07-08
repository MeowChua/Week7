using System;
using Microsoft.AspNetCore.Mvc;
namespace WEB_Front.Pages.Shared.Components.Products
{
	public class Products : ViewComponent
    {
		public Products()
		{
		}
		public IViewComponentResult Invoke()
        {
            return View();
        }
	}
}

