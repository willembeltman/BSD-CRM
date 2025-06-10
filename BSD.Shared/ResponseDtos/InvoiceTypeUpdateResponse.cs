using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTypeUpdateResponse : BaseResponse
{
    public InvoiceType? InvoiceType { get; set; }
}