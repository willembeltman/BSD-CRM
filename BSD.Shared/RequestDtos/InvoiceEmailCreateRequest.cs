using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceEmailCreateRequest : BaseRequest
{
    public InvoiceEmail InvoiceEmail { get; set; } = new InvoiceEmail();
}