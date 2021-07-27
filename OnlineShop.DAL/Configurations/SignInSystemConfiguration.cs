using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class SignInSystemConfiguration : IEntityTypeConfiguration<SignInSystem>
    {
        public void Configure(EntityTypeBuilder<SignInSystem> builder)
        {
            builder.HasKey(e => e.SignInId)
                    .HasName("PK__SignInSy__873BAB2569C095F8");
            builder.ToTable("SignInSystem");
            builder.HasIndex(e => e.Password, "UQ__SignInSy__87909B15AE94ED29")
                .IsUnique();
            builder.HasIndex(e => e.Email, "UQ__SignInSy__A9D1053429CDE352")
                .IsUnique();
            builder.Property(e => e.SignInId).HasColumnName("SignInID");
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
