using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class RecordForWalkConfiguration : IEntityTypeConfiguration<RecordForWalkEntity>
    {
        public void Configure(EntityTypeBuilder<RecordForWalkEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User)
                .WithMany(u => u.RecordsForWalk)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Animal)
                .WithMany(a => a.RecordsForWalk)
                .HasForeignKey(r => r.AnimalId);

            builder.Property(r => r.DateOfRecord)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("timestamp");
        }
    }
}
