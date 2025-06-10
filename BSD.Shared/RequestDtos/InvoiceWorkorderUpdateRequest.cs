using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceWorkorderUpdateRequest : BaseRequest
{
    public InvoiceWorkorder InvoiceWorkorder { get; set; } = new InvoiceWorkorder();
}