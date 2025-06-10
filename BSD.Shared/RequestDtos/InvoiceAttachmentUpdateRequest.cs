using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceAttachmentUpdateRequest : BaseRequest
{
    public InvoiceAttachment InvoiceAttachment { get; set; } = new InvoiceAttachment();
    public IFormFile? File { get; set; }
}