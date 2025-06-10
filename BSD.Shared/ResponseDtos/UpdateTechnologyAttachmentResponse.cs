using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTechnologyAttachmentResponse : BaseResponse
{
    public TechnologyAttachment? TechnologyAttachment { get; set; }
}