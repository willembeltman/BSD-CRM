using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentAttachmentCreateResponse : BaseResponse
{
    public DocumentAttachment? DocumentAttachment { get; set; }
}