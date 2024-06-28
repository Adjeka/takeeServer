using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(User.MAX_SURNAME_LENGTH);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(User.MAX_NAME_LENGTH);

            builder.Property(u => u.Patronymic)
                .IsRequired()
                .HasMaxLength(User.MAX_PATRONYMIC_LENGTH);

            builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.ComplexProperty(u => u.Email, b =>
            {
                b.IsRequired();
                b.Property(e => e.Mail).HasColumnName("Email");
            });

            builder.ComplexProperty(u => u.PhoneNumber, b =>
            {
                b.IsRequired();
                b.Property(ph => ph.Number).HasColumnName("PhoneNumber");
            });

            builder.HasOne(u => u.UserRole)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.UserRoleId);

            builder.Property(u => u.Login)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasMany(u => u.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);

            builder.HasMany(u => u.RecordsForWalk)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
        }
    }
}
