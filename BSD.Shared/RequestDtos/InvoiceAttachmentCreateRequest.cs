using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class InvoiceAttachmentCreateRequest : BaseRequest
{
    public InvoiceAttachment InvoiceAttachment { get; set; } = new InvoiceAttachment();
    public IFormFile? File { get; set; }
}