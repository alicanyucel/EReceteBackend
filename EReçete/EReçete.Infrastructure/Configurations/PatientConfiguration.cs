using EReçete.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EReçete.Infrastructure.Configurations
{
    internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
            builder.HasIndex(p => p.IdentityNumber).IsUnique();
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(20)");
        }
    }
}
