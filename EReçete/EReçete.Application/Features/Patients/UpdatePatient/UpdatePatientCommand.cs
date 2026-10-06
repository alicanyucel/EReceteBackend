using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.UpdatePatient
{
    public sealed record UpdatePatientCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string IdentityNumber,
        DateOnly BirthDate,
        string? PhoneNumber) : IRequest<Result<string>>;
}
