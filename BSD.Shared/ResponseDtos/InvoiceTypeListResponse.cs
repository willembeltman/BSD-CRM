using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTypeListResponse : BaseResponse
{
    public InvoiceType[] InvoiceTypes { get; set; } = [];
}