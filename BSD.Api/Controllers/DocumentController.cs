using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DocumentController(IDocumentService document) : ControllerBase
{
    [HttpPost]
    public DocumentCreateResponse Create(DocumentCreateRequest request) 
        => document.Create(request);

    [HttpPost]
    public DocumentReadResponse Read(DocumentReadRequest request) 
        => document.Read(request);

    [HttpPost]
    public DocumentUpdateResponse Update(DocumentUpdateRequest request) 
        => document.Update(request);

    [HttpPost]
    public DocumentDeleteResponse Delete(DocumentDeleteRequest request) 
        => document.Delete(request);

    [HttpPost]
    public DocumentListResponse List(DocumentListRequest request) 
        => document.List(request);
}
