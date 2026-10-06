using EReçete.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EReçete.Infrastructure.Configurations
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.DiplomaNumber).HasColumnType("varchar(20)");
            builder.HasIndex(p => p.DiplomaNumber).IsUnique();
            builder.Property(p => p.Branch).HasColumnType("varchar(100)");
        }
    }
}
