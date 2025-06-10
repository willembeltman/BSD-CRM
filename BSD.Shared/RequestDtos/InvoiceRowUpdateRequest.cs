using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceRowUpdateRequest : BaseRequest
{
    public InvoiceRow InvoiceRow { get; set; } = new InvoiceRow();
}