using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoicePriceReadResponse : BaseResponse
{
    public InvoicePrice? InvoicePrice { get; set; }
}