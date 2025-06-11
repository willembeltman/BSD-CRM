using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyUserController(ICompanyUserService companyuser) : ControllerBase
{
    [HttpPost]
    public CompanyUserCreateResponse Create(CompanyUserCreateRequest request)
        => companyuser.Create(request);

    [HttpPost]
    public CompanyUserReadResponse Read(CompanyUserReadRequest request)
        => companyuser.Read(request);

    [HttpPost]
    public CompanyUserUpdateResponse Update(CompanyUserUpdateRequest request)
        => companyuser.Update(request);

    [HttpPost]
    public CompanyUserDeleteResponse Delete(CompanyUserDeleteRequest request)
        => companyuser.Delete(request);

    [HttpPost]
    public CompanyUserListResponse List(CompanyUserListRequest request)
        => companyuser.List(request);
}
