using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.CreateDoctor
{
    public sealed record CreateDoctorCommand(
        string FirstName,
        string LastName,
        string DiplomaNumber,
        string Branch) : IRequest<Result<string>>;
}
