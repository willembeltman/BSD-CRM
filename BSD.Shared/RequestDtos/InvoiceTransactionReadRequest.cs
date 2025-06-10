namespace BSD.Shared.RequestDtos;

public class InvoiceTransactionReadRequest : BaseRequest
{
    public long InvoiceTransactionId { get; set; }
}