using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IAuthenticationService
{
    ForgotPasswordResponse ForgotPassword(ForgotPasswordRequest request);
    LoginResponse Login(LoginRequest request);
    RegisterResponse Register(RegisterRequest request);
}
