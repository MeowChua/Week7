//using API_Back.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Projects.Shared;
using WEB_Front.Data;

namespace WEB_Front.Pages.Detail
{
    public class IndexModel : PageModel
    {
        public Product DBProduct = new Product();
        public List<ProductVariant> DBProductVariants = new List<ProductVariant>();
        public List<Rating> rating = new List<Rating>();

        public List<Product> DBProduct_tmp = new List<Product>();
        public Product Product = new Product();
        public Random rand = new Random();
        public List<Product> DBProductList = new List<Product>();
        public int tmpID=0;
        public async Task<IActionResult> OnGetAsync(int ProductID, int Idrate)
        {
            GetData gd = new GetData();
            DBProduct = await gd.GetProductsByIDAsync(ProductID);
            DBProductVariants = await gd.GetListProductVariantAsync();
            DBProductList = await gd.GetListProductsAsync();
            DBProduct_tmp = await gd.GetListProductsRandomByNumber(4);
            this.tmpID=ProductID;
            return Page();
        }



        
        public async Task<IActionResult> OnPost(int ProductID)
        {
            var i = int.Parse(Request.Form["star"]);
            GetData gd = new GetData();
            rating =await gd.GetListRatingAsync();
            var count_bc = 1;
            foreach (var vr in rating)
            {
                count_bc++;
            }
            Rating rat = new Rating();
            rat.Id = count_bc;
            rat.IdProduct = ProductID;
            rat.rating = i;
            SetData sd = new SetData();
            sd.SetListRating(rat);
            return Page();
        }
    }
}
