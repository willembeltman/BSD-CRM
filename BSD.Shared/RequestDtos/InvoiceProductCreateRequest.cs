using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceProductCreateRequest : BaseRequest
{
    public InvoiceProduct InvoiceProduct { get; set; } = new InvoiceProduct();
}