using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.DeleteMedicationById
{
    public sealed record DeleteMedicationByIdCommand(
        Guid Id) : IRequest<Result<string>>;
}
