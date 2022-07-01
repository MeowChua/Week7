using front.Data;
using front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace front.Pages
{
    public class ProductDetailModel : PageModel
    {

        public ProductDetailModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
            public Product DBProduct = new Product();
            public List<ProductVariant> DBProductVariants = new List<ProductVariant>();
            //public List<Rating> rating = new List<Rating>();
        private readonly ApplicationDbContext _context;
        // private APIHelper _api = new APIHelper();
        private int id;
            public async Task<IActionResult> OnGetAsync(int ProductID, int Idrate)
            {
                //Console.WriteLine("1");
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7289/");
                
                //  id = "1";
                 string a = "";
            // https://localhost:7289/api/Product
            //var result = await _http.GetFromJsonAsync<IActionResult<Product>>($"api/product");
            this.id = ProductID;
            var res = await client.GetAsync("api/Product/"+id);
                var result = res.Content.ReadAsStringAsync().Result;
                DBProduct = JsonConvert.DeserializeObject<Product>(result);

                var resV = await client.GetAsync("api/ProductVariants/");
                var resultV = resV.Content.ReadAsStringAsync().Result;
                DBProductVariants = JsonConvert.DeserializeObject<List<ProductVariant>>(resultV);

               


                return Page();

            }
        public List<Rating> rating = new List<Rating>();
        public async Task<IActionResult> OnPost(int IdProduct)
             {
                 var i =int.Parse (Request.Form["star"]);

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
            rat.rating = i;


            _context.Rating.Add(rat);
            _context.SaveChanges();

            return Page();
             }
            /*
            public async Task<IActionResult> OnGetIDAsync(string ProductID)
             {
            Console.WriteLine(ProductID);
            
            /*
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7124/ProductDetail?ProductID=1");

            string id = "1";
            string a = "";
            // https://localhost:7289/api/Product
            //var result = await _http.GetFromJsonAsync<IActionResult<Product>>($"api/product");
            var res = await client.GetAsync("api/Product/" + id);
            var result = res.Content.ReadAsStringAsync().Result;
            DBProduct = JsonConvert.DeserializeObject<Product>(result);

            //var resV = await client.GetAsync("api/ProductVariants/"+id);
            //var resultV = resV.Content.ReadAsStringAsync().Result;
            //DBProductVariants = JsonConvert.DeserializeObject<ProductVariant>(resultV);
            
            return Page();
            }*/
         
        
    }
}
