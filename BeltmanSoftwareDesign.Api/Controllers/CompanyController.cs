using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController(ICompanyService CompanyService) : BaseControllerBase
{
    [HttpPost]
    public CompanyCreateResponse Create(CompanyCreateRequest request) 
        => CompanyService.Create(request);

    [HttpPost]
    public CompanyReadResponse Read(CompanyReadRequest request) 
        => CompanyService.Read(request);

    [HttpPost]
    public CompanyUpdateResponse Update(CompanyUpdateRequest request) 
        => CompanyService.Update(request);

    [HttpPost]
    public CompanyDeleteResponse Delete(CompanyDeleteRequest request) 
        => CompanyService.Delete(request);

    [HttpPost]
    public CompanyListResponse List(CompanyListRequest request) 
        => CompanyService.List(request);
}
