using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IDocumentService
{
    DocumentCreateResponse Create(DocumentCreateRequest request);
    DocumentDeleteResponse Delete(DocumentDeleteRequest request);
    DocumentListResponse List(DocumentListRequest request);
    DocumentReadResponse Read(DocumentReadRequest request);
    DocumentUpdateResponse Update(DocumentUpdateRequest request);
}