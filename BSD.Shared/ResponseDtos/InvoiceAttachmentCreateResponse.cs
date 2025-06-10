using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceAttachmentCreateResponse : BaseResponse
{
    public InvoiceAttachment? InvoiceAttachment { get; set; }
}