using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTypeReadResponse : BaseResponse
{
    public InvoiceType? InvoiceType { get; set; }
}