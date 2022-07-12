using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Back.Data;
using API_Back.Models;
using Projects.Shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : Controller
    {
        private readonly DataContext dt;
        public CartItemsController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            return Ok(dt.CartItems.ToArray());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetCartById([FromRoute] int id)
        {
            var pd =await dt.CartItems.FindAsync(id);
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
            var ar = dt.CartItems.Find(id);
            if (ar != null)
            {
                dt.Remove(ar);
                dt.SaveChanges();
                return Ok(ar);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddCartItemsAsync(AddCartItemRequest add)
        {

            var cart = new CartItem()
            {
                UserId = add.UserId,
                ProductId = add.ProductId,
                ProductTypeId = add.ProductTypeId,
                Quantity = 1
            };
            await dt.CartItems.AddAsync(cart);
            await dt.SaveChangesAsync();
            return Ok(cart);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateCartItem([FromRoute] int Id, UpdateCartItemRequest udp)
        {
            var cart = await dt.CartItems.FindAsync(Id);
            if (cart != null)
            {
                cart.ProductId = udp.ProductId;
                cart.ProductTypeId = udp.ProductTypeId;
                cart.Quantity = udp.Quantity;
                cart.UserId = udp.UserId;
                
                await dt.SaveChangesAsync();
                return Ok(cart);
            }
            return NotFound();
        }

    }
}

