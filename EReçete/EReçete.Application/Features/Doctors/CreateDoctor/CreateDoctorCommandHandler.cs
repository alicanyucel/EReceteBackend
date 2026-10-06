using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.CreateDoctor
{
    internal sealed class CreateDoctorCommandHandler(
        IRepository<Doctor> doctorRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateDoctorCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            bool isDiplomaNumberExists = await doctorRepository
                .AnyAsync(p => p.DiplomaNumber == request.DiplomaNumber, cancellationToken);

            if (isDiplomaNumberExists)
            {
                return Result<string>.Failure("Bu diploma numarasına sahip doktor zaten mevcut");
            }

            Doctor doctor = mapper.Map<Doctor>(request);

            await doctorRepository.AddAsync(doctor, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Doktor kaydı başarıyla tamamlandı";
        }
    }
}
