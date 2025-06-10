using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoicePriceCreateRequest : BaseRequest
{
    public InvoicePrice InvoicePrice { get; set; } = new InvoicePrice();
}