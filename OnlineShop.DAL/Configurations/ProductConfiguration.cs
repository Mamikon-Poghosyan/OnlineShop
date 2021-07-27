using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.ProductName)
                .HasMaxLength(15)
                .IsUnicode(false);
            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__1FEDB87C");
        }
    }
}
