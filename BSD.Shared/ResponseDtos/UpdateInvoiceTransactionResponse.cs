using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceTransactionResponse : BaseResponse
{
    public InvoiceTransaction? InvoiceTransaction { get; set; }
}