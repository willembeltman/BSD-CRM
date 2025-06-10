using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceWorkorderListResponse : BaseResponse
{
    public InvoiceWorkorder[] InvoiceWorkorders { get; set; } = [];
}