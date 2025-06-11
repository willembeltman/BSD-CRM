namespace BSD.Shared.Dtos;

public class InvoiceProduct
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public string? ProductName { get; set; }
    public long ProductId { get; set; }
    public string? InvoiceName { get; set; }
    public int Amount { get; set; }
}