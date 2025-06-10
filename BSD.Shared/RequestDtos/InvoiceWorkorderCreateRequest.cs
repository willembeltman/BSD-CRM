using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceWorkorderCreateRequest : BaseRequest
{
    public InvoiceWorkorder InvoiceWorkorder { get; set; } = new InvoiceWorkorder();
}