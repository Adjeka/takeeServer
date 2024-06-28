using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(Breed.MAX_NAME_LENGTH);

            builder.HasMany(b => b.Animals)
                .WithOne(a => a.Breed)
                .HasForeignKey(a => a.BreedId);
        }
    }
}
