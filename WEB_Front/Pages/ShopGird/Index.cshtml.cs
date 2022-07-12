using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projects.Shared;
using WEB_Front.Data;

namespace WEB_Front.Pages.ShopGird
{
	public class IndexModel : PageModel
    {
        public List<Product> DBProduct = new List<Product>();
        public List<Rating> DBRating = new List<Rating>();
        public List<point> points = new List<point>();
        public List<Product> l3_1 = new List<Product>();
        public List<Product> l3_2 = new List<Product>();
        public List<ProductVariant> DBProductVariants = new List<ProductVariant>();
        public async Task<IActionResult> OnGetAsync()
        {
            GetData gd = new GetData();
            DBProduct = await gd.GetListProductsAsync();
            DBRating = await gd.GetListRatingAsync();
            points = gd.GetListPoints(DBProduct, DBRating);
            DBProductVariants = await gd.GetListProductVariantAsync();
            points = gd.GetListPoints(DBProduct, DBRating);
            l3_1 = await gd.GetListProductsRandomByNumber(3);
            l3_2 = await gd.GetListProductsRandomByNumber(3);
            return Page();
        }
    }
}
