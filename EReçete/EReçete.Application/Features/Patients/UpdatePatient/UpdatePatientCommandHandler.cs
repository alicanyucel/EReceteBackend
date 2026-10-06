using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.UpdatePatient
{
    internal sealed class UpdatePatientCommandHandler(
        IRepository<Patient> patientRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdatePatientCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await patientRepository
                .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (patient is null)
            {
                return Result<string>.Failure("Hasta bulunamadı");
            }

            bool isIdentityNumberExists = await patientRepository
                .AnyAsync(p => p.IdentityNumber == request.IdentityNumber && p.Id != request.Id, cancellationToken);

            if (isIdentityNumberExists)
            {
                return Result<string>.Failure("Bu TC kimlik numarasına sahip başka bir hasta zaten mevcut");
            }

            mapper.Map(request, patient);

            patientRepository.Update(patient);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Hasta kaydı başarıyla güncellendi";
        }
    }
}
