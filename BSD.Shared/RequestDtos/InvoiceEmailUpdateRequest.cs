using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceEmailUpdateRequest : BaseRequest
{
    public InvoiceEmail InvoiceEmail { get; set; } = new InvoiceEmail();
}