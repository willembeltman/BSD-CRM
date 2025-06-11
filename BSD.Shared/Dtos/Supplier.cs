namespace BSD.Shared.Dtos;

public class Supplier
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? CountryId { get; set; }
    public string? CountryName { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Postalcode { get; set; }
    public string? Place { get; set; }
    public string? PhoneNumber { get; set; }
    public string? RekeningNumber { get; set; }
    public bool Publiekelijk { get; set; }
}