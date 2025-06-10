using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyAttachmentUpdateResponse : BaseResponse
{
    public TechnologyAttachment? TechnologyAttachment { get; set; }
}