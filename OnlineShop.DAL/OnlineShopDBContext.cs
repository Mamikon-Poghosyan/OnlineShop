using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.DAL.Configurations;

namespace OnlineShop.DAL
{
    public partial class OnlineShopDBContext : DbContext
    {
        public OnlineShopDBContext()
        {
        }
        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SignInSystem> SignInSystems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SignInSystemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
