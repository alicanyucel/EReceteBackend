using MediatR;
using TS.Result;

namespace EReçete.Application.Features.Patients.DeletePatientById
{
    public sealed record DeletePatientByIdCommand(
        Guid Id) : IRequest<Result<string>>;
}
