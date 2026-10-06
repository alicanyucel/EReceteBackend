using EReçete.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EReçete.Infrastructure.Configurations
{
    internal sealed class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(p => p.PrescriptionNumber).HasColumnType("varchar(50)");
            builder.HasIndex(p => p.PrescriptionNumber).IsUnique();
            builder.Property(p => p.Diagnosis).HasColumnType("varchar(250)");

            builder
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Doctor)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Medications)
                .WithMany(p => p.Prescriptions)
                .UsingEntity("PrescriptionMedications");
        }
    }
}
