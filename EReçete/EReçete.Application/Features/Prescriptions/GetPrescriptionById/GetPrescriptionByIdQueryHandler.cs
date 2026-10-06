using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.GetPrescriptionById
{
    internal sealed class GetPrescriptionByIdQueryHandler(
        IRepository<Prescription> prescriptionRepository) : IRequestHandler<GetPrescriptionByIdQuery, Result<Prescription>>
    {
        public async Task<Result<Prescription>> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            Prescription? prescription = await prescriptionRepository
                .GetAll()
                .Include(p => p.Medications)
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (prescription is null)
            {
                return Result<Prescription>.Failure("Reçete bulunamadı");
            }

            return prescription;
        }
    }
}
