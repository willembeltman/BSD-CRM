using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoicePriceUpdateRequest : BaseRequest
{
    public InvoicePrice InvoicePrice { get; set; } = new InvoicePrice();
}