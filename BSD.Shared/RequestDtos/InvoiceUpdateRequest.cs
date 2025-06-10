using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceUpdateRequest : BaseRequest
{
    public Invoice Invoice { get; set; } = new Invoice();
}