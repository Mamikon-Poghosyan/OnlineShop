using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");
            builder.Property(e => e.CategoryName)
                .HasMaxLength(15)
                .IsUnicode(false);
            builder.Property(e => e.Description).HasColumnType("ntext");
        }
    }
}
