using EReçete.Domain.Abstractions;

namespace EReçete.Domain.Entities
{
    public sealed class Doctor : Entity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string DiplomaNumber { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<Prescription> Prescriptions { get; set; } = new();
    }
}
