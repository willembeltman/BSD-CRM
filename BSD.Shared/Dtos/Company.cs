namespace BSD.Shared.Dtos;

public class Company
{
    public long Id { get; set; }
    public long? CountryId { get; set; }
    public string? CountryName { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Postalcode { get; set; }
    public string? Place { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? BtwNumber { get; set; }
    public string? KvkNumber { get; set; }
    public string? Iban { get; set; }
    public string? PayNL_ApiToken { get; set; }
    public string? PayNL_ServiceId { get; set; }
}