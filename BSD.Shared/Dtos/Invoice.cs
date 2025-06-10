using System;

namespace BSD.Shared.Dtos;

public class Invoice
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? InvoiceTypeId { get; set; }
    public long? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public long? CustomerId { get; set; }
    public long? IsPayedInCash_By_CompanyUserId { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public bool IsPayedInCash { get; set; }
}