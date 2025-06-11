using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class DocumentAttachmentCreateRequest : BaseRequest
{
    public DocumentAttachment DocumentAttachment { get; set; } = new DocumentAttachment();
    public IFormFile? File { get; set; }
}