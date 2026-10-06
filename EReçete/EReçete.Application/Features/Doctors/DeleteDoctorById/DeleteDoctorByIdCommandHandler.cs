using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.DeleteDoctorById
{
    internal sealed class DeleteDoctorByIdCommandHandler(
        IRepository<Doctor> doctorRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await doctorRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (doctor is null)
            {
                return Result<string>.Failure("Doktor bulunamadı");
            }

            doctorRepository.Delete(doctor);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Doktor kaydı başarıyla silindi";
        }
    }
}
