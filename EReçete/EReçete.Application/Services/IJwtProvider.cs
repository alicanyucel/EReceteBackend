using EReçete.Application.Features.Auth.Login;
using EReçete.Domain.Entities;

namespace EReçete.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
