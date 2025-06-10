using System;


namespace BSD.Shared.Dtos;

public class TaxRate
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long CountryId { get; set; }
    public string? CountryName { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Percentage { get; set; }
}