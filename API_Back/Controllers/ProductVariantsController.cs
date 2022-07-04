using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Back.Data;
using API_Back.Models;
using Projects.Shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : Controller
    {
        private readonly DataContext dt;
        public ProductVariantsController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public IActionResult GetProductVariants()
        {
            return Ok(dt.ProductVariants.ToList());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public async Task< IActionResult> GetProductVariantById([FromRoute] int id)
        {
            var pd =await dt.ProductVariants.FindAsync(id);
            if (pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }


        [HttpPost]
        public IActionResult AddProductVariants(AddProductVariantsRequest add)
        {

            var productVariants = new ProductVariant()
            {

                Product = add.Product,
                ProductId = add.ProductId,
                ProductType = add.ProductType,
                ProductTypeId = add.ProductTypeId,
                Price = add.Price,
                OriginalPrice = add.OriginalPrice,
                Visible = add.Visible,
                Deleted = add.Deleted,
                Editing = add.Editing,
                IsNew = add.IsNew
            };
            dt.ProductVariants.Add(productVariants);
            dt.SaveChanges();
            return Ok(productVariants);
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ar = dt.ProductVariants.Find(id);
            if (ar != null)
            {
                dt.Remove(ar);
                dt.SaveChanges();
                return Ok(ar);
            }
            return NotFound();
        }

    }
}

