using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Projects.Shared;
using WEB_Front.Data;
using Shared;
    

namespace WEB_Front.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        public List<Product> DBProduct = new List<Product>();
        public List<CartItem> DBCartItem = new List<CartItem>();
        public List<MixCartProduct> DBMixCart = new List<MixCartProduct>();
        public int userid;
        public int sum;
        public async Task<IActionResult> OnGetAsync(int UserID)
        {
            GetData gd = new GetData();
            DBProduct = await gd.GetListCartbyUserID(1);
            DBCartItem = await gd.GetListCartByID();
            DBMixCart = await gd.GetListMixCartProduct(1);
            this.userid = 1;//UserID;
            this.sum=gd.GetTotalWithList(DBMixCart);
            return Page();
        }
    }
}