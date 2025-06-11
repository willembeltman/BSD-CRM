using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IDocumentAttachmentService
{
    DocumentAttachmentCreateResponse Create(DocumentAttachmentCreateRequest request);
    DocumentAttachmentDeleteResponse Delete(DocumentAttachmentDeleteRequest request);
    DocumentAttachmentListResponse List(DocumentAttachmentListRequest request);
    DocumentAttachmentReadResponse Read(DocumentAttachmentReadRequest request);
    DocumentAttachmentUpdateResponse Update(DocumentAttachmentUpdateRequest request);
}