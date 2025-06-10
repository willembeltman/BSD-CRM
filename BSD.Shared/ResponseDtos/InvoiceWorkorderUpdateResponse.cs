using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceWorkorderUpdateResponse : BaseResponse
{
    public InvoiceWorkorder? InvoiceWorkorder { get; set; }
}