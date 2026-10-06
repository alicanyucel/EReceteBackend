using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.DeleteDoctorById
{
    public sealed record DeleteDoctorByIdCommand(
        Guid Id) : IRequest<Result<string>>;
}
