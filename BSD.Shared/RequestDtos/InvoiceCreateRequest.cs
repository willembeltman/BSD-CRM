using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceCreateRequest : BaseRequest
{
    public Invoice Invoice { get; set; } = new Invoice();
}
