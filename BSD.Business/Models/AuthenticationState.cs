using BSD.Data.Entities;

namespace BSD.Business.Models;

public class AuthenticationState : BSD.Shared.Dtos.State
{
    public bool Success { get; set; }
    public User? DbUser { get; set; }
    public Company? DbCurrentCompany { get; set; }
    public Country? DbCountry { get; set; }
}
