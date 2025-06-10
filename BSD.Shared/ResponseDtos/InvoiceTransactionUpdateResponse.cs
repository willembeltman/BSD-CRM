using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTransactionUpdateResponse : BaseResponse
{
    public InvoiceTransaction? InvoiceTransaction { get; set; }
}