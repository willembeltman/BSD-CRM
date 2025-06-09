using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController(ICompanyService company) : ControllerBase
{
    [HttpPost]
    public CompanyCreateResponse Create(CompanyCreateRequest request) 
        => company.Create(request);

    [HttpPost]
    public CompanyReadResponse Read(CompanyReadRequest request) 
        => company.Read(request);

    [HttpPost]
    public CompanyUpdateResponse Update(CompanyUpdateRequest request) 
        => company.Update(request);

    [HttpPost]
    public CompanyDeleteResponse Delete(CompanyDeleteRequest request) 
        => company.Delete(request);

    [HttpPost]
    public CompanyListResponse List(CompanyListRequest request) 
        => company.List(request);
}
