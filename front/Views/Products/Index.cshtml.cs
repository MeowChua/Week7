using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace front.Views.Products
{
	public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _http;
        public void OnGet()
        {
        }
        public IndexModel(IHttpClientFactory http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<Product> AdminProducts { get; set; }
        public event Action ProductsChanged;
        /*
        public async Task<List<Product>> GetProduct()
        {
            var result = await _http.GetAsync("api/product");
            return JsonConvert.DeserializeObject<List<Product>>(await result.Content.ReadAsStringAsync());
        }
        */
        public async Task<List<Product>> GetProducts()
        {
            var client = _http.CreateClient();
            //client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync("/api/product");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
        }

        public List<Product> ls = new List<Product>(){

           new Product () {
            Id=1,
            Title= "Dầu Gội L'Oreal Professionnel Chăm Sóc Da Đầu Nhờn 300ml",
            Description= "Dầu Gội L'Oreal Professionnel Chăm Sóc Da Đầu Nhờn là sản phẩm dầu gội đến từ thương hiệu chăm sóc tóc chuyên nghiệp L'Oréal Professionnel của Pháp, với công thức tinh thể nước tinh khiết, kết hợp Citramine và Vitamin E giúp loại bỏ bụi bẩn, dầu thừa và bã nhờn trên da đầu. Sản phẩm giúp da đầu sạch sẽ, cân bằng độ ẩm, tóc được nuôi dưỡng và bảo vệ giải quyết các vấn đề về tóc và da đầu. Bạn có thể sử dụng như dầu gội đầu hàng ngày hoặc không thường xuyên để làm giảm dầu trên tóc.",
            ImageUrl= "https=//media.hasaki.vn/catalog/product/f/a/facebook-dynamic-dau-goi-l-oreal-professionnel-cham-soc-da-dau-nhon-300ml_img_358x358_843626_fit_center.jpg",
            CategoryId= 1,
            Featured= true,
            Visible= true,
            Deleted= false,
            Editing= false,
            IsNew= false
            }
        };
        
        
    }
}
