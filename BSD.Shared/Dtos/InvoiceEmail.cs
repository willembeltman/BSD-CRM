using System;


namespace BSD.Shared.Dtos;

public class InvoiceEmail
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
    public string? EmailFrom { get; set; }
    public string? EmailTo { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime DateVerzonden { get; set; } = DateTime.Now;
    public bool InvoiceGezien { get; set; }
    public DateTime? DateInvoiceGezien { get; set; }
    public bool EmailGezien { get; set; }
    public DateTime? DateEmailGezien { get; set; }
}