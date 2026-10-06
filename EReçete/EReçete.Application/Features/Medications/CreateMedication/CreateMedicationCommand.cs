using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.CreateMedication
{
    public sealed record CreateMedicationCommand(
        string Name,
        string Barcode,
        string Description) : IRequest<Result<string>>;
}
