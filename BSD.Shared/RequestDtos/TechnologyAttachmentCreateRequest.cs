using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TechnologyAttachmentCreateRequest : BaseRequest
{
    public TechnologyAttachment TechnologyAttachment { get; set; } = new TechnologyAttachment();
    public IFormFile? File { get; set; }
}