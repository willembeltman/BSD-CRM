using BSD.Business.ServiceHandlers;
using BSD.Data.Entities;

namespace BSD.Business.Models;

public class AuthenticationState : Shared.Dtos.State
{
    public bool Success { get; set; }

    public ClientBearer? DbClientBearer { get; set; }
    public ClientDevice? DbClientDevice { get; set; }
    public ClientIpAddress? DbClientLocation { get; set; }
    public User? DbUser { get; set; }
    public Company? DbCurrentCompany { get; set; }
}
