using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceEmailCreateResponse : BaseResponse
{
    public InvoiceEmail? InvoiceEmail { get; set; }
}