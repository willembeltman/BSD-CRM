using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceTypeUpdateRequest : BaseRequest
{
    public InvoiceType InvoiceType { get; set; } = new InvoiceType();
}