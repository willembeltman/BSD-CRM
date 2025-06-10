using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IInvoiceAttachmentService
{
    InvoiceAttachmentCreateResponse Create(InvoiceAttachmentCreateRequest request);
    InvoiceAttachmentDeleteResponse Delete(InvoiceAttachmentDeleteRequest request);
    InvoiceAttachmentListResponse List(InvoiceAttachmentListRequest request);
    InvoiceAttachmentReadResponse Read(InvoiceAttachmentReadRequest request);
    InvoiceAttachmentUpdateResponse Update(InvoiceAttachmentUpdateRequest request);
}