using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.Property(ur => ur.Name)
                .IsRequired();

            builder.HasMany(ur => ur.Users)
                .WithOne(u => u.UserRole)
                .HasForeignKey(u => u.UserRoleId);
        }
    }
}
