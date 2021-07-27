using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;
using System;

namespace OnlineShop.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.NumberPhone, "UQ__Users__A2BA67DA0417AD00")
                    .IsUnique();
            builder.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            builder.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(e => e.NumberPhone)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength(true);
            builder.Property(e => e.Wallet).HasColumnType("decimal(18, 0)");
            builder.HasOne(d => d.UserNavigation)
                .WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_SignInSystem");
        }
    }
}
