using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceRowCreateResponse : BaseResponse
{
    public InvoiceRow? InvoiceRow { get; set; }
}