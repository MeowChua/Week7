using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API_Back.Data;
using API_Back.Models;
using Projects.Shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Back.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext dt;
        public ProductController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dt.Products.Include(p => p.Images).Include(q => q.Variants).ToArrayAsync());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var pd = await dt.Products.FindAsync(id);
            if(pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ar = dt.Products.Find(id);
            if (ar != null)
            {
                dt.Remove(ar);
                dt.SaveChanges();
                return Ok(ar);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductsAsync(AddProductsRequest add)
        {

            var pro = new Product()
            {
                Id = add.Id,
                Title = add.Title,
                Description = add.Description,
                ImageUrl = add.ImageUrl,
                Images = add.Images,
                Category = add.Category,
                CategoryId = add.CategoryId,
                Featured = add.Featured,
                Variants = add.Variants,
                Visible = add.Visible,
                Deleted = add.Deleted,
                Editing = add.Editing,
                IsNew = add.IsNew

            };
            await dt.Products.AddAsync(pro);
            await dt.SaveChangesAsync();
            return Ok(pro);
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> updateProject([FromRoute] int Id, UpdateProductsRequest udp)
        {
            var products = await dt.Products.FindAsync(Id);
                if (products != null)
                {
                //products.Id = udp.Id;
                products.Title = udp.Title;
                products.Description=udp.Description;
                products.ImageUrl=udp.ImageUrl;
                products.Images = udp.Images;
                products.Category = udp.Category;
                products.CategoryId = udp.CategoryId;
                products.Featured = udp.Featured;
                products.Variants = udp.Variants;
                products.Visible = udp.Visible;
                products.Deleted = udp.Deleted;
                products.Editing = udp.Editing;
                products.IsNew = udp.IsNew;
                await dt.SaveChangesAsync();
                return Ok(products);
                }
            return NotFound();
        }

    }
    
}

