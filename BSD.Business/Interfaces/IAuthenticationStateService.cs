using BSD.Business.Models;
using BSD.Shared.RequestDtos;

namespace BSD.Business.Interfaces;

public interface IAuthenticationStateService
{
    AuthenticationState GetState(BaseRequest request);
}