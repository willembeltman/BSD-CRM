using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceRowReadResponse : BaseResponse
{
    public InvoiceRow? InvoiceRow { get; set; }
}