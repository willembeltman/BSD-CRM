using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class InvoiceAttachmentCreateRequest : BaseRequest
{
    public InvoiceAttachment InvoiceAttachment { get; set; } = new InvoiceAttachment();
}