using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.UpdateMedication
{
    internal sealed class UpdateMedicationCommandHandler(
        IRepository<Medication> medicationRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateMedicationCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
        {
            Medication? medication = await medicationRepository
                .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (medication is null)
            {
                return Result<string>.Failure("İlaç bulunamadı");
            }

            bool isBarcodeExists = await medicationRepository
                .AnyAsync(p => p.Barcode == request.Barcode && p.Id != request.Id, cancellationToken);

            if (isBarcodeExists)
            {
                return Result<string>.Failure("Bu barkoda sahip başka bir ilaç zaten mevcut");
            }

            mapper.Map(request, medication);

            medicationRepository.Update(medication);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "İlaç kaydı başarıyla güncellendi";
        }
    }
}
