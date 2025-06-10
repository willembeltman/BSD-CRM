using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceTransactionUpdateRequest : BaseRequest
{
    public InvoiceTransaction InvoiceTransaction { get; set; } = new InvoiceTransaction();
}