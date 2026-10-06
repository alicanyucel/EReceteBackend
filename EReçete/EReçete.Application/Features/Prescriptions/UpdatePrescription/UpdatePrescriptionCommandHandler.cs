using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.UpdatePrescription
{
    internal sealed class UpdatePrescriptionCommandHandler(
        IRepository<Prescription> prescriptionRepository,
        IRepository<Medication> medicationRepository,
        IRepository<Patient> patientRepository,
        IRepository<Doctor> doctorRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdatePrescriptionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            Prescription? prescription = await prescriptionRepository
                .GetAllWithTacking()
                .Include(p => p.Medications)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (prescription is null)
            {
                return Result<string>.Failure("Reçete bulunamadı");
            }

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

            prescription.PrescriptionDate = request.PrescriptionDate;
            prescription.PatientId = request.PatientId;
            prescription.DoctorId = request.DoctorId;
            prescription.Diagnosis = request.Diagnosis;
            prescription.DoctorNotes = request.DoctorNotes;
            prescription.Medications.Clear();
            foreach (Medication medication in medications)
            {
                prescription.Medications.Add(medication);
            }

            prescriptionRepository.Update(prescription);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete kaydı başarıyla güncellendi";
        }
    }
}
