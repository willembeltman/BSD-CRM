using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentAttachmentUpdateResponse : BaseResponse
{
    public DocumentAttachment? DocumentAttachment { get; set; }
}