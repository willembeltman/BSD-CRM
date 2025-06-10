using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class WorkorderAttachmentUpdateRequest : BaseRequest
{
    public WorkorderAttachment WorkorderAttachment { get; set; } = new WorkorderAttachment();
    public IFormFile? File { get; set; }
}