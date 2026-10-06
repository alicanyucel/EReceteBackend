using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.CreatePatient
{
    public sealed record CreatePatientCommand(
        string FirstName,
        string LastName,
        string IdentityNumber,
        DateOnly BirthDate,
        string? PhoneNumber) : IRequest<Result<string>>;
}
