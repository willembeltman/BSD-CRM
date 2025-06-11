namespace BSD.Shared.Dtos;

public class BankStatementInvoice
{
    public long Id { get; set; }
    public long? BankStatementId { get; set; }
    public string? BankStatementName { get; set; }
    public long? InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
}