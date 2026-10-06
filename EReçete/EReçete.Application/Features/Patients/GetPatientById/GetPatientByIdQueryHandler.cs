using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.GetPatientById
{
    internal sealed class GetPatientByIdQueryHandler(
        IRepository<Patient> patientRepository) : IRequestHandler<GetPatientByIdQuery, Result<Patient>>
    {
        public async Task<Result<Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            Patient? patient = await patientRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (patient is null)
            {
                return Result<Patient>.Failure("Hasta bulunamadı");
            }

            return patient;
        }
    }
}
