using Linkoo.Application.Common.Models.Identity;
using Linkoo.Application.Common.Models.Result;

namespace Linkoo.Application.Contracts.Identity.Services
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> Login(AuthRequest request);
        Task<Result<RegistrationResponse>> Register(RegistrationRequest request);
    }
}