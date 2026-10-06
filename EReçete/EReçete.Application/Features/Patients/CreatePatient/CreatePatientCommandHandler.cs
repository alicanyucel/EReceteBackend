using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.CreatePatient
{
    internal sealed class CreatePatientCommandHandler(
        IRepository<Patient> patientRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreatePatientCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            bool isIdentityNumberExists = await patientRepository
                .AnyAsync(p => p.IdentityNumber == request.IdentityNumber, cancellationToken);

            if (isIdentityNumberExists)
            {
                return Result<string>.Failure("Bu TC kimlik numarasına sahip hasta zaten mevcut");
            }

            Patient patient = mapper.Map<Patient>(request);

            await patientRepository.AddAsync(patient, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Hasta kaydı başarıyla tamamlandı";
        }
    }
}
