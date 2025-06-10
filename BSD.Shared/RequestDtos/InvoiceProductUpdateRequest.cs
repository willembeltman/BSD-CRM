using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceProductUpdateRequest : BaseRequest
{
    public InvoiceProduct InvoiceProduct { get; set; } = new InvoiceProduct();
}