using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoicePriceResponse : BaseResponse
{
    public InvoicePrice? InvoicePrice { get; set; }
}