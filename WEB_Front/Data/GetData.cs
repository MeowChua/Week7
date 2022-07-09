using Newtonsoft.Json;
using Projects.Shared;

namespace WEB_Front.Data
{
    public class GetData
    {
        public String s = "https://localhost:7124/";
        private readonly HttpClient _http;
        public GetData()
        {

        }
        //Product
        public async Task<List<Product>> GetListProductsAsync()
        {
            var products = new List<Product>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var res = await client.GetAsync("api/Product");
            var result = res.Content.ReadAsStringAsync().Result;
            products = JsonConvert.DeserializeObject<List<Product>>(result);
            return products;
        }
        public async Task<Product> GetProductsByIDAsync(int id)
        {
            var products = new Product();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var res = await client.GetAsync("api/Product/" + id);
            var result = res.Content.ReadAsStringAsync().Result;
            products = JsonConvert.DeserializeObject<Product>(result);
            return products;
        }

        //Rating
        public async Task<List<Rating>> GetListRatingAsync()
        {
            var Rating = new List<Rating>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var resV1 = await client.GetAsync("api/Rating/");
            var resultV1 = resV1.Content.ReadAsStringAsync().Result;
            Rating = JsonConvert.DeserializeObject<List<Rating>>(resultV1);
            return Rating;
        }

        //ProductsVariant
        public async Task<List<ProductVariant>> GetListProductVariantAsync()
        {
            var productVariant = new List<ProductVariant>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var res = await client.GetAsync("api/ProductVariants/");
            var result = res.Content.ReadAsStringAsync().Result;
            productVariant = JsonConvert.DeserializeObject<List<ProductVariant>>(result);
            return productVariant;
        }
        //GetListPoint
        public List<point> GetListPoints(List<Product> DBProduct, List<Rating> DBRating)
        {
            var Ps = new List<point>();
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
                Ps.Add(pts);
            }
            return Ps;
        }
        //GetListCategories
        public async Task<List<Category>> GetCategories(List<Category> DBCategories)
        {
            var DBcategory = new List<Category>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var res = await client.GetAsync("api/Categories/");
            var result = res.Content.ReadAsStringAsync().Result;
            DBcategory = JsonConvert.DeserializeObject<List<Category>>(result);
            return DBcategory;
        }

        //GetListCategoriesByID
        public async Task<Category> GetCategoriesbyId(int ID)
        {
            var DBcategory = new Category();
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            var res = await client.GetAsync("api/Categories/" + ID);
            var result = res.Content.ReadAsStringAsync().Result;
            DBcategory = JsonConvert.DeserializeObject<Category>(result);
            return DBcategory;
        }

    }
}
