using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Projects.Shared;
using WEB_Front.Data;

namespace WEB_Front.Pages.Home
{
    public class IndexModel : PageModel
    {
        
        public List<Product> DBProduct = new List<Product>();
        public List<Rating> DBRating = new List<Rating>();
        public List<point> points = new List<point>();
        public async Task<IActionResult> OnGetAsync()
        {
            GetData gd = new GetData();
            DBProduct =await gd.GetListProductsAsync();
            DBRating = await gd.GetListRatingAsync();
            points = gd.GetListPoints(DBProduct, DBRating);
          
            return Page();
        }
    }
}
