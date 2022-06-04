

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RepositoryLayer.Entity;

namespace RestaurantApp.Models
{
    public class RestaurentDBContext : DbContext
    {
        public RestaurentDBContext(DbContextOptions<RestaurentDBContext> options) : base(options)
        {
        }
        

            public DbSet<Customer> Customers { get; set; }
            public DbSet<Item> Items { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItems> OrderItems { get; set; }
            public DbSet<Address> Addresses { get; set; }


        
    }
}
