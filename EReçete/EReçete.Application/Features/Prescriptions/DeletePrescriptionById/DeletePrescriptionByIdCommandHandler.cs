using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.DeletePrescriptionById
{
    internal sealed class DeletePrescriptionByIdCommandHandler(
        IRepository<Prescription> prescriptionRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeletePrescriptionByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeletePrescriptionByIdCommand request, CancellationToken cancellationToken)
        {
            Prescription? prescription = await prescriptionRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (prescription is null)
            {
                return Result<string>.Failure("Reçete bulunamadı");
            }

            prescriptionRepository.Delete(prescription);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete kaydı başarıyla silindi";
        }
    }
}
