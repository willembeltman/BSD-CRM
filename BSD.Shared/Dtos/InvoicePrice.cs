using System;


namespace BSD.Shared.Dtos;

public class InvoicePrice
{
    public long Id { get; set; }
    public long? InvoiceId { get; set; }
    public long? TaxRateId { get; set; }
    public double Price { get; set; }
}