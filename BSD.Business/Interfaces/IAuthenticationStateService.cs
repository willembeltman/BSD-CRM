using BSD.Business.Models;
using BSD.Shared.Requests;

namespace BSD.Business.Interfaces;

public interface IAuthenticationStateService
{
    AuthenticationState GetState(Request request);
}