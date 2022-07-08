using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Back.Data;
using Projects.Shared;
using API_Back.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly DataContext dt;
        public CategoriesController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await dt.Categories.ToArrayAsync());
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategories(AddCategoriesRequest add)
        {

            var ratg = new Category()
            {
                Id = add.Id,
                Name = add.Name,
                Url = add.Url,
                Visible = add.Visible,
                Deleted = add.Deleted,

                Editing = add.Editing,
                IsNew = add.IsNew

            };
            await dt.Categories.AddAsync(ratg);
            await dt.SaveChangesAsync();
            return Ok(ratg);
        }
        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetCategoriesById([FromRoute] int id)
        {
            var pd =await dt.Categories.FindAsync(id);
            if (pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ar =await dt.Categories.FindAsync(id);
            if (ar != null)
            {
                dt.Remove(ar);
                await dt.SaveChangesAsync();
                return Ok(ar);
            }
            return NotFound();
        }
        

    }
}

