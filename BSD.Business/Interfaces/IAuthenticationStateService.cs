using BSD.Business.Models;
using BSD.Data.Entities;
using BSD.Shared.RequestDtos;

namespace BSD.Business.Interfaces;

public interface IAuthenticationStateService
{
    string? IpAddress { get; }

    Task<User> CreateUser(string username, string email, string phoneNumber, string password);
    Task<ClientBearer?> GetClientBearer(User dbuser);
    Task<AuthenticationState> GetState(BaseRequest request);
}