using front.Data;
using front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages
{
    public class OrdersPageModel : PageModel
    {
        public List<PizzaOrder> pz = new List<PizzaOrder>();
        private readonly ApplicationDbContext _context;
        public OrdersPageModel(ApplicationDbContext context)
        {
            _context = context;

        }
        public void OnGet()
        {
            pz = _context.PizzaOrders.ToList();
        }
    }
}
