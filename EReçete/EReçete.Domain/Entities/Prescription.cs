using EReçete.Domain.Abstractions;

namespace EReçete.Domain.Entities
{
    public sealed class Prescription : Entity
    {
        public string PrescriptionNumber { get; set; } = string.Empty;
        public DateTime PrescriptionDate { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
        public string Diagnosis { get; set; } = string.Empty;
        public string? DoctorNotes { get; set; }
        public List<Medication> Medications { get; set; } = new();
    }
}
