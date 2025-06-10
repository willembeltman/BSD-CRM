using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentAttachmentListResponse : BaseResponse
{
    public DocumentAttachment[] DocumentAttachments { get; set; } = [];
}