using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class DocumentAttachmentUpdateRequest : BaseRequest
{
    public DocumentAttachment DocumentAttachment { get; set; } = new DocumentAttachment();
    public IFormFile? File { get; set; }
}