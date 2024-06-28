using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<AnimalEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nickname)
                .IsRequired()
                .HasMaxLength(Animal.MAX_NICKNAME_LENGTH);

            builder.HasOne(a => a.TypeOfAnimals)
                .WithMany(t => t.Animals)
                .HasForeignKey(a => a.TypeOfAnimalsId);

            builder.HasOne(a => a.Breed)
                .WithMany(b => b.Animals)
                .HasForeignKey(a => a.BreedId);

            builder.Property(a => a.Height)
                .IsRequired();

            builder.Property(a => a.Weight)
                .IsRequired();

            builder.ComplexProperty(a => a.Gender, b =>
            {
                b.IsRequired();
                b.Property(g => g.Value).HasColumnName("Gender");
            });

            builder.Property(a => a.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Color)
                .IsRequired()
                .HasMaxLength(Animal.MAX_COLOR_LENGTH);

            builder.Property(a => a.DistinguishingMark)
                .IsRequired()
                .HasMaxLength(Animal.MAX_DISTINGUISHINGMARK_LENGTH);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(Animal.MAX_DESCRIPTION_LENGTH);

            builder.HasOne(a => a.Curator)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CuratorId);

            builder.Property(a => a.Photo)
                .IsRequired();

            builder.HasMany(a => a.Favorites)
                .WithOne(f => f.Animal)
                .HasForeignKey(f => f.AnimalId);

            builder.HasMany(a => a.RecordsForWalk)
                .WithOne(r => r.Animal)
                .HasForeignKey(r => r.AnimalId);
        }
    }
}
