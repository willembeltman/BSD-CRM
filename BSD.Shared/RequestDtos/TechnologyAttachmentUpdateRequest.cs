using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TechnologyAttachmentUpdateRequest : BaseRequest
{
    public TechnologyAttachment TechnologyAttachment { get; set; } = new TechnologyAttachment();
}