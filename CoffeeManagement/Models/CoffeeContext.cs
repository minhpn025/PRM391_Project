using System.Data.Entity;

namespace CoffeeManagement.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext() :base("CoffeeConnectionString")
        {
            Database.SetInitializer<CoffeeContext>(new CreateDatabaseIfNotExists<CoffeeContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}