using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface IAuthenticationService
{
    LoginResponse Login(LoginRequest request);
    RegisterResponse Register(RegisterRequest request);
}
