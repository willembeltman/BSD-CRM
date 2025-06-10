using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceEmailListResponse : BaseResponse
{
    public InvoiceEmail[] InvoiceEmails { get; set; } = [];
}