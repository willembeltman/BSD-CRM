using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceWorkorderCreateResponse : BaseResponse
{
    public InvoiceWorkorder? InvoiceWorkorder { get; set; }
}