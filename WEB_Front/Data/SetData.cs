using Projects.Shared;

namespace WEB_Front.Data
{
    public class SetData
    {
        public String s = "https://localhost:7124/";
        private readonly HttpClient _http;
        public SetData() { }


        public async void SetListRating(Rating rat)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            await client.PostAsJsonAsync("api/Rating/", rat);
        }
        public async void SetListCart(CartItem Cart)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            await client.PostAsJsonAsync("api/CartItems", Cart);
        }
        //update Quality 
        public async void UpdateQuality(int Quality,int productID){
            var client = new HttpClient();
            client.BaseAddress=new Uri(s);
            var crt = new CartItem();
            GetData gd = new GetData();
            crt = await gd.GetListCartByIDProduct(productID);
            crt.Quantity=Quality;
            await client.PutAsJsonAsync("api/CartItems/"+productID,crt);
        }
    }
}
