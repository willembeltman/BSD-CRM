using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TechnologyAttachmentListResponse : BaseResponse
{
    public TechnologyAttachment[] TechnologyAttachments { get; set; } = [];
}