using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.UpdatePrescription
{
    public sealed record UpdatePrescriptionCommand(
        Guid Id,
        DateTime PrescriptionDate,
        Guid PatientId,
        Guid DoctorId,
        string Diagnosis,
        string? DoctorNotes,
        List<Guid> MedicationIds) : IRequest<Result<string>>;
}
