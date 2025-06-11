using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankStatementController(IBankStatementService bankstatement) : ControllerBase
{
    [HttpPost]
    public BankStatementCreateResponse Create(BankStatementCreateRequest request) 
        => bankstatement.Create(request);

    [HttpPost]
    public BankStatementReadResponse Read(BankStatementReadRequest request) 
        => bankstatement.Read(request);

    [HttpPost]
    public BankStatementUpdateResponse Update(BankStatementUpdateRequest request) 
        => bankstatement.Update(request);

    [HttpPost]
    public BankStatementDeleteResponse Delete(BankStatementDeleteRequest request) 
        => bankstatement.Delete(request);

    [HttpPost]
    public BankStatementListResponse List(BankStatementListRequest request) 
        => bankstatement.List(request);
}
