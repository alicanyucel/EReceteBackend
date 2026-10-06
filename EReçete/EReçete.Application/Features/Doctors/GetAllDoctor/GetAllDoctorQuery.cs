using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.GetAllDoctor
{
    public sealed record GetAllDoctorQuery() : IRequest<Result<List<Doctor>>>;
}
