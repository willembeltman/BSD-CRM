using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceAttachmentReadResponse : BaseResponse
{
    public InvoiceAttachment? InvoiceAttachment { get; set; }
}