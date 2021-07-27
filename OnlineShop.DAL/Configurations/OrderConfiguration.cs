using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.DaliveryDate).HasColumnType("datetime");
            builder.Property(e => e.DateOfReceipt).HasColumnType("datetime");
            builder.Property(e => e.PurchaseDate).HasColumnType("datetime");
            builder.Property(e => e.UserId).HasColumnName("UserID");
            builder.HasOne(d => d.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__1B29035F");
        }
    }
}
