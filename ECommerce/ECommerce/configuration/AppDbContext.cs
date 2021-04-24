
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<UserModel> UserMaster { get; set; }
        // public DbSet<Address> AddressMaster { get; set; }
         public DbSet<ProductModel> ProductMaster { get; set; }
        public DbSet<ComentsModel> CommentMaster { get; set; }
         public DbSet<CartModel> CartMaster { get; set; }
    }
}