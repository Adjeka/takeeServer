using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<FavouriteEntity>
    {
        public void Configure(EntityTypeBuilder<FavouriteEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Animal)
                .WithMany(a => a.Favorites)
                .HasForeignKey(r => r.AnimalId);
        }
    }
}
