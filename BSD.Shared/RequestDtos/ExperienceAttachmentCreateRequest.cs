using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceAttachmentCreateRequest : BaseRequest
{
    public ExperienceAttachment ExperienceAttachment { get; set; } = new ExperienceAttachment();
    public IFormFile? File { get; set; }
}