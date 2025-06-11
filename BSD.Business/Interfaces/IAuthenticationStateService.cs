using BSD.Business.Models;
using BSD.Data.Entities;
using BSD.Shared.RequestDtos;

namespace BSD.Business.Interfaces;

public interface IAuthenticationStateService
{
    string? IpAddress { get; }

    User CreateUser(string username, string email, string phoneNumber, string password);
    ClientBearer? GetClientBearer(User dbuser);
    AuthenticationState GetState(BaseRequest request);
}