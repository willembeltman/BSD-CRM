using BeltmanSoftwareDesign.Business.Models;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Business.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationState GetState(Request request);
        LoginResponse Login(LoginRequest request);
        RegisterResponse Register(RegisterRequest request);
    }
}
