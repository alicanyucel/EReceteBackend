using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.UpdateMedication
{
    public sealed record UpdateMedicationCommand(
        Guid Id,
        string Name,
        string Barcode,
        string Description) : IRequest<Result<string>>;
}
