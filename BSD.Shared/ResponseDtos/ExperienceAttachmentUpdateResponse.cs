using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceAttachmentUpdateResponse : BaseResponse
{
    public ExperienceAttachment? ExperienceAttachment { get; set; }
}