using OnlineShoppingApp.UI.Migrations;
using OnlineShoppingApp.UI.Models;
using System.Data.Entity;

namespace OnlineShoppingApp.UI.DataAccess
{
    public class OnlineShoppingContext : DbContext
    {
        public OnlineShoppingContext() : base("name=OnLineShoppingConnection")
        {
            Database.SetInitializer<OnlineShoppingContext>(new MigrateDatabaseToLatestVersion<OnlineShoppingContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().Property(x => x.UnitCost).HasPrecision(5, 2);
            modelBuilder.Entity<Product>().Property(x => x.UnitCost).HasPrecision(5, 2);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}