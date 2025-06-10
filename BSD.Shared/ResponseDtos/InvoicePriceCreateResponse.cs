using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoicePriceCreateResponse : BaseResponse
{
    public InvoicePrice? InvoicePrice { get; set; }
}