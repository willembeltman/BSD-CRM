using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceAttachmentCreateResponse : BaseResponse
{
    public ExperienceAttachment? ExperienceAttachment { get; set; }
}