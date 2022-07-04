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


        public async Task<IActionResult> OnGetAsync(int ProductID, int Idrate)
        {
            GetData gd = new GetData();
            DBProduct = await gd.GetProductsByIDAsync(ProductID);
            DBProductVariants = await gd.GetListProductVariantAsync();
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
