using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExperienceAttachmentResponse : BaseResponse
{
    public ExperienceAttachment? ExperienceAttachment { get; set; }
}