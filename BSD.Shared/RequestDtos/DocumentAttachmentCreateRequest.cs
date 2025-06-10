using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class DocumentAttachmentCreateRequest : BaseRequest
{
    public DocumentAttachment DocumentAttachment { get; set; } = new DocumentAttachment();
}