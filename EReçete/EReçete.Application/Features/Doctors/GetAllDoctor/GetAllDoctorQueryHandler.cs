using EReçete.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EReçete.Application.Features.Doctors.GetAllDoctor
{
    internal sealed class GetAllDoctorQueryHandler(
        IRepository<Doctor> doctorRepository) : IRequestHandler<GetAllDoctorQuery, Result<List<Doctor>>>
    {
        public async Task<Result<List<Doctor>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            List<Doctor> doctors = await doctorRepository
                .GetAll()
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync(cancellationToken);

            return doctors;
        }
    }
}
