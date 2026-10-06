using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.GetAllMedication
{
    public sealed record GetAllMedicationQuery() : IRequest<Result<List<Medication>>>;
}
