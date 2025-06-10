using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IDocumentTypeService
{
    DocumentTypeCreateResponse Create(DocumentTypeCreateRequest request);
    DocumentTypeDeleteResponse Delete(DocumentTypeDeleteRequest request);
    DocumentTypeListResponse List(DocumentTypeListRequest request);
    DocumentTypeReadResponse Read(DocumentTypeReadRequest request);
    DocumentTypeUpdateResponse Update(DocumentTypeUpdateRequest request);
}