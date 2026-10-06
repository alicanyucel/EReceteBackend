using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Doctors.GetDoctorById
{
    internal sealed class GetDoctorByIdQueryHandler(
        IRepository<Doctor> doctorRepository) : IRequestHandler<GetDoctorByIdQuery, Result<Doctor>>
    {
        public async Task<Result<Doctor>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await doctorRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (doctor is null)
            {
                return Result<Doctor>.Failure("Doktor bulunamadı");
            }

            return doctor;
        }
    }
}
