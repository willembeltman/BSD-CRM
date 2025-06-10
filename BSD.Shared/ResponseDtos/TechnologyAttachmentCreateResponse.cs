using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyAttachmentCreateResponse : BaseResponse
{
    public TechnologyAttachment? TechnologyAttachment { get; set; }
}