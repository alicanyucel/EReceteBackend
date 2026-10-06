using EReçete.Domain.Abstractions;

namespace EReçete.Domain.Entities
{
    public sealed class Patient : Entity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string IdentityNumber { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new();
    }
}
