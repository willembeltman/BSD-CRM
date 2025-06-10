using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTransactionReadResponse : BaseResponse
{
    public InvoiceTransaction? InvoiceTransaction { get; set; }
}