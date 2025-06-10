using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

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
