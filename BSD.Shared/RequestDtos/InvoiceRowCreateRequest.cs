using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceRowCreateRequest : BaseRequest
{
    public InvoiceRow InvoiceRow { get; set; } = new InvoiceRow();
}