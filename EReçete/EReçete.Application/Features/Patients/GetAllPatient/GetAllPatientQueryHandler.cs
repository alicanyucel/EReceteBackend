using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Patients.GetAllPatient
{
    internal sealed class GetAllPatientQueryHandler(
        IRepository<Patient> patientRepository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
    {
        public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            List<Patient> patients = await patientRepository
                .GetAll()
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync(cancellationToken);

            return patients;
        }
    }
}
