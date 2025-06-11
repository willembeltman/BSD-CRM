namespace BSD.Shared.Dtos;

public class InvoiceWorkorder
{
    public long Id { get; set; }
    public long? InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
    public long? WorkorderId { get; set; }
    public string? WorkorderName { get; set; }
}