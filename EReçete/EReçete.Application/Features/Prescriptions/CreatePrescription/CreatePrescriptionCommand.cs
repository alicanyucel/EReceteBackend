using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.CreatePrescription
{
    public sealed record CreatePrescriptionCommand(
        DateTime PrescriptionDate,
        Guid PatientId,
        Guid DoctorId,
        string Diagnosis,
        string? DoctorNotes,
        List<Guid> MedicationIds) : IRequest<Result<string>>;
}
