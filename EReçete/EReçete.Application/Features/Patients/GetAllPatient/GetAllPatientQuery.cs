using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.GetAllPatient
{
    public sealed record GetAllPatientQuery() : IRequest<Result<List<Patient>>>;
}
