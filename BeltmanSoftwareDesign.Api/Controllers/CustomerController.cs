using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CustomerController(ICustomerService CustomerService) : BaseControllerBase
{
    [HttpPost]
    public CustomerCreateResponse Create(CustomerCreateRequest request) 
        => CustomerService.Create(request);

    [HttpPost]
    public CustomerReadResponse Read(CustomerReadRequest request) 
        => CustomerService.Read(request);

    [HttpPost]
    public CustomerUpdateResponse Update(CustomerUpdateRequest request) 
        => CustomerService.Update(request);

    [HttpPost]
    public CustomerDeleteResponse Delete(CustomerDeleteRequest request) 
        => CustomerService.Delete(request);

    [HttpPost]
    public CustomerListResponse List(CustomerListRequest request) 
        => CustomerService.List(request);
}
