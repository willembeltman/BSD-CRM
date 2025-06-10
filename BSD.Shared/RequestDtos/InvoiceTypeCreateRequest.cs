using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceTypeCreateRequest : BaseRequest
{
    public InvoiceType InvoiceType { get; set; } = new InvoiceType();
}