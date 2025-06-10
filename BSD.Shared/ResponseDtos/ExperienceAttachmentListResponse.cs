using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceAttachmentListResponse : BaseResponse
{
    public ExperienceAttachment[] ExperienceAttachments { get; set; } = [];
}