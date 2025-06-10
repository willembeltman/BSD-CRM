using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceAttachmentUpdateRequest : BaseRequest
{
    public ExperienceAttachment ExperienceAttachment { get; set; } = new ExperienceAttachment();
}