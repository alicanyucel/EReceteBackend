using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.UpdateDoctor
{
    public sealed record UpdateDoctorCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string DiplomaNumber,
        string Branch) : IRequest<Result<string>>;
}
