using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderDet__08D097C1119F9DDC");
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__23BE4960");
            builder.HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__24B26D99");
        }
    }
}
