using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.CreatePrescription
{
    internal sealed class CreatePrescriptionCommandHandler(
        IRepository<Prescription> prescriptionRepository,
        IRepository<Medication> medicationRepository,
        IRepository<Patient> patientRepository,
        IRepository<Doctor> doctorRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreatePrescriptionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            bool isPatientExists = await patientRepository
                .AnyAsync(p => p.Id == request.PatientId, cancellationToken);

            if (!isPatientExists)
            {
                return Result<string>.Failure("Hasta bulunamadı");
            }

            bool isDoctorExists = await doctorRepository
                .AnyAsync(p => p.Id == request.DoctorId, cancellationToken);

            if (!isDoctorExists)
            {
                return Result<string>.Failure("Doktor bulunamadı");
            }

            List<Medication> medications = await medicationRepository
                .GetAll()
                .Where(p => request.MedicationIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            if (medications.Count != request.MedicationIds.Distinct().Count())
            {
                return Result<string>.Failure("Seçilen ilaçlardan bazıları bulunamadı");
            }

            Prescription prescription = new()
            {
                PrescriptionNumber = GeneratePrescriptionNumber(),
                PrescriptionDate = request.PrescriptionDate,
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Diagnosis = request.Diagnosis,
                DoctorNotes = request.DoctorNotes,
                Medications = medications
            };

            await prescriptionRepository.AddAsync(prescription, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete kaydı başarıyla tamamlandı";
        }

        private static string GeneratePrescriptionNumber()
        {
            return $"ER-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}";
        }
    }
}
