using System;


namespace BSD.Shared.Dtos;

public class BankStatementInvoice
{
    public long Id { get; set; }
    public long? BankStatementId { get; set; }
    public long? InvoiceId { get; set; }
}