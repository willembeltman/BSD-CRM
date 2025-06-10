using System;


namespace BSD.Shared.Dtos;

public class ProductPrice
{
    public long Id { get; set; }
    public long? ProductId { get; set; }
    public long? TaxRateId { get; set; }
    public double Price { get; set; }
}