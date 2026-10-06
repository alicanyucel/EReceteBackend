using EReçete.Domain.Entities;
using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.GetAllPrescription
{
    public sealed record GetAllPrescriptionQuery() : IRequest<Result<List<Prescription>>>;
}
