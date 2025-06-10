using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTransactionCreateResponse : BaseResponse
{
    public InvoiceTransaction? InvoiceTransaction { get; set; }
}