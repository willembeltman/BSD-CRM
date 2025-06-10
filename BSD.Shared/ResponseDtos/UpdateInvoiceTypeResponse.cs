using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceTypeResponse : BaseResponse
{
    public InvoiceType? InvoiceType { get; set; }
}