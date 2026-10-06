using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.GetMedicationById
{
    public sealed record GetMedicationByIdQuery(
        Guid Id) : IRequest<Result<Medication>>;
}
