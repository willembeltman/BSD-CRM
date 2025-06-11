using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class WorkorderAttachmentCreateRequest : BaseRequest
{
    public WorkorderAttachment WorkorderAttachment { get; set; } = new WorkorderAttachment();
    public IFormFile? File { get; set; }
}