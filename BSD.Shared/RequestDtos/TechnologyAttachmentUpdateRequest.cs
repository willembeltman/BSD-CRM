using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class TechnologyAttachmentUpdateRequest : BaseRequest
{
    public TechnologyAttachment TechnologyAttachment { get; set; } = new TechnologyAttachment();
    public IFormFile? File { get; set; }
}