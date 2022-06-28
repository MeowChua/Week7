using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using front.Views.Products;
using shared;
using front.Views.Products;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace front.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
       
        public IActionResult Index()
        {
            //var dataset =await GetProducts();
            return View(); //dataset);
        }
        
    }
}

