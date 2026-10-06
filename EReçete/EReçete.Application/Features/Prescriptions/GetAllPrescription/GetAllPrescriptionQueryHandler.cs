using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.GetAllPrescription
{
    internal sealed class GetAllPrescriptionQueryHandler(
        IRepository<Prescription> prescriptionRepository) : IRequestHandler<GetAllPrescriptionQuery, Result<List<Prescription>>>
    {
        public async Task<Result<List<Prescription>>> Handle(GetAllPrescriptionQuery request, CancellationToken cancellationToken)
        {
            List<Prescription> prescriptions = await prescriptionRepository
                .GetAll()
                .Include(p => p.Medications)
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .OrderByDescending(p => p.PrescriptionDate)
                .ToListAsync(cancellationToken);

            return prescriptions;
        }
    }
}
