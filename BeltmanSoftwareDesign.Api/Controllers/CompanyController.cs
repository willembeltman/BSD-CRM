using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController(ICompany Company) : BaseControllerBase
{
    [HttpPost]
    public CompanyCreateResponse Create(CompanyCreateRequest request) 
        => Company.Create(request);

    [HttpPost]
    public CompanyReadResponse Read(CompanyReadRequest request) 
        => Company.Read(request);

    [HttpPost]
    public CompanyUpdateResponse Update(CompanyUpdateRequest request) 
        => Company.Update(request);

    [HttpPost]
    public CompanyDeleteResponse Delete(CompanyDeleteRequest request) 
        => Company.Delete(request);

    [HttpPost]
    public CompanyListResponse List(CompanyListRequest request) 
        => Company.List(request);
}
