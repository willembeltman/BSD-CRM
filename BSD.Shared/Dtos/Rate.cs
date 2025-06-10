using System;


namespace BSD.Shared.Dtos;

public class Rate
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public long TaxRateId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}