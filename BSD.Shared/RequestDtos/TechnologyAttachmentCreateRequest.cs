using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class TechnologyAttachmentCreateRequest : BaseRequest
{
    public TechnologyAttachment TechnologyAttachment { get; set; } = new TechnologyAttachment();
    public IFormFile? File { get; set; }
}