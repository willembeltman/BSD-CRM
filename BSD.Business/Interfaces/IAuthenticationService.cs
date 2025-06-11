using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IAuthenticationService
{
    Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request);
    Task<LoginResponse> Login(LoginRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
}
