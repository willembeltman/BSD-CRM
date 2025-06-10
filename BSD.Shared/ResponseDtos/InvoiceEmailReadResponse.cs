using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceEmailReadResponse : BaseResponse
{
    public InvoiceEmail? InvoiceEmail { get; set; }
}