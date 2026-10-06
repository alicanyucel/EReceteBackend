using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.DeletePatientById
{
    internal sealed class DeletePatientByIdCommandHandler(
        IRepository<Patient> patientRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeletePatientByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await patientRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (patient is null)
            {
                return Result<string>.Failure("Hasta bulunamadı");
            }

            patientRepository.Delete(patient);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Hasta kaydı başarıyla silindi";
        }
    }
}
