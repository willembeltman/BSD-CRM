using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceWorkorderResponse : BaseResponse
{
    public InvoiceWorkorder? InvoiceWorkorder { get; set; }
}