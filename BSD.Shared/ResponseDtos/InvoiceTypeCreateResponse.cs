using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTypeCreateResponse : BaseResponse
{
    public InvoiceType? InvoiceType { get; set; }
}