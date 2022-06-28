using front.Models;
using Microsoft.EntityFrameworkCore;
namespace front.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <PizzaOrder> PizzaOrders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
