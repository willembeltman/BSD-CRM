using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class WorkorderAttachmentCreateRequest : BaseRequest
{
    public WorkorderAttachment WorkorderAttachment { get; set; } = new WorkorderAttachment();
    public IFormFile? File { get; set; }
}