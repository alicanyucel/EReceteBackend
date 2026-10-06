using EReçete.Domain.Abstractions;

namespace EReçete.Domain.Entities
{
    public sealed class Medication : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Prescription> Prescriptions { get; set; } = new();
    }
}
