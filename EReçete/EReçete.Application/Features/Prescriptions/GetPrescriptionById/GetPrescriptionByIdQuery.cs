using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.GetPrescriptionById
{
    public sealed record GetPrescriptionByIdQuery(
        Guid Id) : IRequest<Result<Prescription>>;
}
