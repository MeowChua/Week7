using front.Models;
using front.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using front.APIHelper;
using Newtonsoft.Json;
using NuGet.Packaging;

namespace front.Pages
{
    public class PizzaModel : PageModel
    {
        /*
        public List<PizzasModel> fakePizzaDB = new List<PizzasModel>()
        {
            new PizzasModel()
            {
                ImageTitle="Margerita",
                PizzaName="Margerita",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Bolognese",
                PizzaName="Bolognese",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            }/*, 
            new PizzasModel()
            {
                ImageTitle="Hamaiian",
                PizzaName="Hamaiian",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Carbonara",
                PizzaName="Carbonara",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="MeatFeast",
                PizzaName="MeatFeast",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Mushroom",
                PizzaName="Mushroom",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Pepperoni",
                PizzaName="Pepperoni",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Seafood",
                PizzaName="Seafood",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            },
            new PizzasModel()
            {
                ImageTitle="Vegetarian",
                PizzaName="Vegetarian",
                BasePrice=2,
                TomatoSauce = true,
                Cheese = true,
                FinalPrice=4
            }

        };
        */
        private readonly HttpClient _http;
        public List<Product> DBProduct = new List<Product>();
        public List<ProductVariant> DBProductVariants = new List<ProductVariant>();
        public List<Rating> DBRating = new List<Rating>();
        // private APIHelper _api = new APIHelper();
        public List<point> points = new List<point>();
        public async Task<IActionResult> OnGetAsync()
        {
            Console.WriteLine("1");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289/");
            // https://localhost:7289/api/Product
            //var result = await _http.GetFromJsonAsync<IActionResult<Product>>($"api/product");
            var res = await client.GetAsync("api/Product");
            var result = res.Content.ReadAsStringAsync().Result;
            DBProduct = JsonConvert.DeserializeObject<List<Product>>(result);

            var resV = await client.GetAsync("api/ProductVariants");
            var resultV = resV.Content.ReadAsStringAsync().Result;
            DBProductVariants = JsonConvert.DeserializeObject<List<ProductVariant>>(resultV);

            var resV1 = await client.GetAsync("api/Rating");
            var resultV1 = resV1.Content.ReadAsStringAsync().Result;
            DBRating = JsonConvert.DeserializeObject<List<Rating>>(resultV1);

            foreach (var pb in DBProduct)
            {
                int count = 1;
                int j = 0;
                int a = 0, sum = 0;
                foreach (var ra in DBRating)
                {
                    if (pb.Id == ra.IdProduct)
                    {
                        count++;
                        a += ra.rating;
                        sum = a / count;
                    }
                }
                var pts = new point(sum, pb.Id);
                points.Add(pts);
            }
            return Page();

        }
        
    }
}
