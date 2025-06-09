using BeltmanSoftwareDesign.Business.Models;
using BeltmanSoftwareDesign.Shared.RequestJsons;

namespace BeltmanSoftwareDesign.Business.Interfaces;

public interface IAuthenticationStateService
{
    AuthenticationState GetState(Request request);
}