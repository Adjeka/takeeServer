using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Configurations
{
    public class CuratorConfiguration : IEntityTypeConfiguration<CuratorEntity>
    {
        public void Configure(EntityTypeBuilder<CuratorEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(Curator.MAX_SURNAME_LENGTH);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(Curator.MAX_NAME_LENGTH);

            builder.Property(c => c.Patronymic)
                .IsRequired()
                .HasMaxLength(Curator.MAX_PATRONYMIC_LENGTH);

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

            builder.HasMany(c => c.Animals)
                .WithOne(a => a.Curator)
                .HasForeignKey(a => a.CuratorId);
        }
    }
}
