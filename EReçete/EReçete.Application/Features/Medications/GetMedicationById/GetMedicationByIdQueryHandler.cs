using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Medications.GetMedicationById
{
    internal sealed class GetMedicationByIdQueryHandler(
        IRepository<Medication> medicationRepository) : IRequestHandler<GetMedicationByIdQuery, Result<Medication>>
    {
        public async Task<Result<Medication>> Handle(GetMedicationByIdQuery request, CancellationToken cancellationToken)
        {
            Medication? medication = await medicationRepository
                .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (medication is null)
            {
                return Result<Medication>.Failure("İlaç bulunamadı");
            }

            return medication;
        }
    }
}
