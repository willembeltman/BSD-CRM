using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceAttachmentUpdateResponse : BaseResponse
{
    public InvoiceAttachment? InvoiceAttachment { get; set; }
}