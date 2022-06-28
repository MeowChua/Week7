using front.Data;
using front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Checkout
{
    [BindProperties(SupportsGet = true )]
    public class CheckoutModel : PageModel
    {
        
        public String PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public String ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;
        public CheckoutModel(ApplicationDbContext context )
        {
            _context = context;
        }
        public void OnGet()
        {
            if (String.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if (String.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }
            PizzaOrder pz = new PizzaOrder();

            pz.PizzaName = PizzaName;
            pz.BasePrice=PizzaPrice;

            _context.PizzaOrders.Add(pz);

            _context.SaveChanges();
        }
    }
}
