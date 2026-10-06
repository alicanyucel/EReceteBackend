using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.GetPatientById
{
    public sealed record GetPatientByIdQuery(
        Guid Id) : IRequest<Result<Patient>>;
}
