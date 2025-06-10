using System;


namespace BSD.Shared.Dtos;

public class InvoiceProduct
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public long ProductId { get; set; }
    public int Amount { get; set; }
}