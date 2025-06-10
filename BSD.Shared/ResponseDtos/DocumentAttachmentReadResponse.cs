using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentAttachmentReadResponse : BaseResponse
{
    public DocumentAttachment? DocumentAttachment { get; set; }
}