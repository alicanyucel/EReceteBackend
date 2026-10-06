using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.GetDoctorById
{
    public sealed record GetDoctorByIdQuery(
        Guid Id) : IRequest<Result<Doctor>>;
}
