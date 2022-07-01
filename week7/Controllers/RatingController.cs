using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using Week7.Data;
using Week7.Models;

namespace Week7.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly DataContext dt;
        public RatingController(DataContext dt)
        {
            this.dt = dt;
        }

        [HttpGet]
        public async Task<IActionResult> GetRating()
        {
            return Ok(await dt.Rating.ToArrayAsync());
            //return View();
        }

        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetRatingById([FromRoute] int id)
        {
            var pd = await dt.Rating.FindAsync(id);
            if (pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }


        [HttpPost]
        public IActionResult AddRating(AddRatingRequest add)
        {

            var ratg = new Rating()
            {
                Id = add.Id,
                IdProduct = add.IdProduct,
                rating = add.rating
            };

            //dt.Ratings.Add(rat);

            dt.Rating.Add(ratg);

            dt.SaveChanges();
            return Ok(ratg);
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ar = dt.Rating.Find(id);
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

