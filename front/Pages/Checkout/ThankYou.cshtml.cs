using front.Data;
using front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Checkout
{
    public class ThankYouModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        public ThankYouModel(ApplicationDbContext context)
        {
            _context=context;
        }


        private readonly HttpClient _http;
        public Product DBProduct = new Product();
        public List<ProductVariant> DBProductVariants = new List<ProductVariant>();
        public List<Rating> rating = new List<Rating>();
        // private APIHelper _api = new APIHelper();
        private int id;
        public async Task<IActionResult> OnGetAsync(int IdProduct, int Idrate)
        {
            //Console.WriteLine("1");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289/");
            var resV1 = await client.GetAsync("api/Rating/");
            var resultV1 = resV1.Content.ReadAsStringAsync().Result;
            rating = JsonConvert.DeserializeObject<List<Rating>>(resultV1);
            var count = 1;
            foreach (var vr in rating)
            {
                count++;
            }
            Rating rat = new Rating();
            rat.Id = count;
            rat.IdProduct = IdProduct;
            rat.rating = Idrate;


                _context.Rating.Add(rat);
                _context.SaveChanges();
            
            return Page();
        }
    }
}
