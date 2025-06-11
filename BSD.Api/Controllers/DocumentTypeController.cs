using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DocumentTypeController(IDocumentTypeService documenttype) : ControllerBase
{
    [HttpPost]
    public DocumentTypeCreateResponse Create(DocumentTypeCreateRequest request) 
        => documenttype.Create(request);

    [HttpPost]
    public DocumentTypeReadResponse Read(DocumentTypeReadRequest request) 
        => documenttype.Read(request);

    [HttpPost]
    public DocumentTypeUpdateResponse Update(DocumentTypeUpdateRequest request) 
        => documenttype.Update(request);

    [HttpPost]
    public DocumentTypeDeleteResponse Delete(DocumentTypeDeleteRequest request) 
        => documenttype.Delete(request);

    [HttpPost]
    public DocumentTypeListResponse List(DocumentTypeListRequest request) 
        => documenttype.List(request);
}
