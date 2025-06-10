using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateInvoiceAttachmentResponse : BaseResponse
{
    public InvoiceAttachment? InvoiceAttachment { get; set; }
}