namespace BSD.Shared.RequestDtos;

public class InvoiceTransactionDeleteRequest : BaseRequest
{
    public long InvoiceTransactionId { get; set; }
}