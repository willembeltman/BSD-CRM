using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateDocumentAttachmentResponse : BaseResponse
{
    public DocumentAttachment? DocumentAttachment { get; set; }
}