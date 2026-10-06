using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Prescriptions.DeletePrescriptionById
{
    public sealed record DeletePrescriptionByIdCommand(
        Guid Id) : IRequest<Result<string>>;
}
