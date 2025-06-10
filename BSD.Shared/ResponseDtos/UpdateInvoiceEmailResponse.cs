using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceEmailResponse : BaseResponse
{
    public InvoiceEmail? InvoiceEmail { get; set; }
}