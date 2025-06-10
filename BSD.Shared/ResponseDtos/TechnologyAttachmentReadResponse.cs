using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyAttachmentReadResponse : BaseResponse
{
    public TechnologyAttachment? TechnologyAttachment { get; set; }
}