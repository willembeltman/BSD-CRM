using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SupplierController(ISupplierService supplier) : ControllerBase
{
    [HttpPost]
    public SupplierCreateResponse Create(SupplierCreateRequest request) 
        => supplier.Create(request);

    [HttpPost]
    public SupplierReadResponse Read(SupplierReadRequest request) 
        => supplier.Read(request);

    [HttpPost]
    public SupplierUpdateResponse Update(SupplierUpdateRequest request) 
        => supplier.Update(request);

    [HttpPost]
    public SupplierDeleteResponse Delete(SupplierDeleteRequest request) 
        => supplier.Delete(request);

    [HttpPost]
    public SupplierListResponse List(SupplierListRequest request) 
        => supplier.List(request);
}
