using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.CreateMedication
{
    internal sealed class CreateMedicationCommandHandler(
        IRepository<Medication> medicationRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateMedicationCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
        {
            bool isBarcodeExists = await medicationRepository
                .AnyAsync(p => p.Barcode == request.Barcode, cancellationToken);

            if (isBarcodeExists)
            {
                return Result<string>.Failure("Bu barkoda sahip ilaç zaten mevcut");
            }

            Medication medication = mapper.Map<Medication>(request);

            await medicationRepository.AddAsync(medication, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "İlaç kaydı başarıyla tamamlandı";
        }
    }
}
