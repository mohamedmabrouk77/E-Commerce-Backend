using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
