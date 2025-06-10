using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoicePriceUpdateResponse : BaseResponse
{
    public InvoicePrice? InvoicePrice { get; set; }
}