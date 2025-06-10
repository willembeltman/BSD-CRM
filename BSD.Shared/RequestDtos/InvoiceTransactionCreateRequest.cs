using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceTransactionCreateRequest : BaseRequest
{
    public InvoiceTransaction InvoiceTransaction { get; set; } = new InvoiceTransaction();
}