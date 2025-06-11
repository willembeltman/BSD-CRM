namespace BSD.Shared.Dtos;

public class InvoiceTransaction
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
    public long TransactionId { get; set; }
}