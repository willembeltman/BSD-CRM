using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IAuthenticationService
{
    LoginResponse Login(LoginRequest request);
    RegisterResponse Register(RegisterRequest request);
}
