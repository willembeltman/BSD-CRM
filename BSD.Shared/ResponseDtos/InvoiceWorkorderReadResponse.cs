using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceWorkorderReadResponse : BaseResponse
{
    public InvoiceWorkorder? InvoiceWorkorder { get; set; }
}