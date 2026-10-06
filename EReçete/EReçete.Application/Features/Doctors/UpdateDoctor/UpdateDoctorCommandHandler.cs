using AutoMapper;
using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.UpdateDoctor
{
    internal sealed class UpdateDoctorCommandHandler(
        IRepository<Doctor> doctorRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateDoctorCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await doctorRepository
                .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (doctor is null)
            {
                return Result<string>.Failure("Doktor bulunamadı");
            }

            bool isDiplomaNumberExists = await doctorRepository
                .AnyAsync(p => p.DiplomaNumber == request.DiplomaNumber && p.Id != request.Id, cancellationToken);

            if (isDiplomaNumberExists)
            {
                return Result<string>.Failure("Bu diploma numarasına sahip başka bir doktor zaten mevcut");
            }

            mapper.Map(request, doctor);

            doctorRepository.Update(doctor);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Doktor kaydı başarıyla güncellendi";
        }
    }
}
