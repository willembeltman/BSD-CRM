using System;


namespace BSD.Shared.Dtos;

public class Customer
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public long? CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Postalcode { get; set; }
    public string? Place { get; set; }
    public string? PhoneNumber { get; set; }
    public string? InvoiceEmail { get; set; }
    public bool Publiekelijk { get; set; }
}