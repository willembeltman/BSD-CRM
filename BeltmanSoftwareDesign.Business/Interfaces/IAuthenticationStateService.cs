using BeltmanSoftwareDesign.Business.Models;
using BeltmanSoftwareDesign.Shared.Requests;

namespace BeltmanSoftwareDesign.Business.Interfaces;

public interface IAuthenticationStateService
{
    AuthenticationState GetState(Request request);
}