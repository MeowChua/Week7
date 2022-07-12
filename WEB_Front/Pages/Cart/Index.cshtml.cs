using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Projects.Shared;
using Shared;
using WEB_Front.Data;


    

namespace WEB_Front.Pages.Cart
{
    public class IndexModel : PageModel
    {
        public List<Product> DBProduct = new List<Product>();
        public List<CartItem> DBCartItem = new List<CartItem>();
        public List<MixCartProduct> DBMixCart = new List<MixCartProduct>();
        public int userid;
        public int sum;
        public async Task<IActionResult> OnGetAsync(int UserID, int ProductID)
        {
            GetData gd = new GetData();
            var protemp = await gd.GetProductsByIDAsync(ProductID);
            var cart = new CartItem();
            cart.ProductId=ProductID;
            cart.Quantity=1;
            cart.ProductTypeId = 1;
            cart.UserId=1; // UserID
            SetData sd = new SetData();
            sd.SetListCart(cart);
            DBProduct = await gd.GetListCartbyUserID(1);
            DBCartItem = await gd.GetListCartByID();
            DBMixCart = await gd.GetListMixCartProduct(1);
            this.userid = 1;//UserID;
            this.sum=gd.GetTotalWithList(DBMixCart);
            return Page();
        }
        public async Task<IActionResult> OnPost(int ProductId){
            var i = int.Parse(Request.Form["qua"]);
            SetData sd = new SetData();
            sd.UpdateQuality(i,ProductId);
            return Page();
        }
    }
}