using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceEmailUpdateResponse : BaseResponse
{
    public InvoiceEmail? InvoiceEmail { get; set; }
}