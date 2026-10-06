using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.DeleteMedicationById
{
    internal sealed class DeleteMedicationByIdCommandHandler(
        IRepository<Medication> medicationRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteMedicationByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteMedicationByIdCommand request, CancellationToken cancellationToken)
        {
            Medication? medication = await medicationRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (medication is null)
            {
                return Result<string>.Failure("İlaç bulunamadı");
            }

            medicationRepository.Delete(medication);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "İlaç kaydı başarıyla silindi";
        }
    }
}
