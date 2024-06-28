using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class TypeOfAnimalsConfiguration : IEntityTypeConfiguration<TypeOfAnimalsEntity>
    {
        public void Configure(EntityTypeBuilder<TypeOfAnimalsEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(TypeOfAnimals.MAX_NAME_LENGTH);

            builder.HasMany(t => t.Animals)
                .WithOne(a => a.TypeOfAnimals)
                .HasForeignKey(a => a.TypeOfAnimalsId);
        }
    }
}
