using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Medications.GetAllMedication
{
    internal sealed class GetAllMedicationQueryHandler(
        IRepository<Medication> medicationRepository) : IRequestHandler<GetAllMedicationQuery, Result<List<Medication>>>
    {
        public async Task<Result<List<Medication>>> Handle(GetAllMedicationQuery request, CancellationToken cancellationToken)
        {
            List<Medication> medications = await medicationRepository
                .GetAll()
                .OrderBy(p => p.Name)
                .ToListAsync(cancellationToken);

            return medications;
        }
    }
}
