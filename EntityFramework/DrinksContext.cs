using Lemonade.Notes;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.EntityFramework
{
    public class DrinksContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DrinksContext(DbContextOptions options) : base(options)
        {

        }
    }
    // public class OrdersContext : DbContext
    // {
    //     public DbSet<Order> Orders { get; set; }

    //     public OrdersContext(DbContextOptions options) : base(options)
    //     {

    //     }
    // }
}