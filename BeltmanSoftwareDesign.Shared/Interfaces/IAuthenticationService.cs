using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IAuthenticationService
{
    LoginResponse Login(LoginRequest request);
    RegisterResponse Register(RegisterRequest request);
}
