using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceAttachmentListResponse : BaseResponse
{
    public InvoiceAttachment[] InvoiceAttachments { get; set; } = [];
}