using EReçete.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EReçete.Infrastructure.Configurations
{
    internal sealed class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.Property(p => p.Name).HasColumnType("varchar(100)");
            builder.Property(p => p.Barcode).HasColumnType("varchar(50)");
            builder.Property(p => p.Description).HasColumnType("varchar(500)");
            builder.HasIndex(p => p.Barcode).IsUnique();
        }
    }
}
