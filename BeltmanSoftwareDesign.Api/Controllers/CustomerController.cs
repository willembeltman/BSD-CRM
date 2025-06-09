using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CustomerController(ICustomerService customer) : ControllerBase
{
    [HttpPost]
    public CustomerCreateResponse Create(CustomerCreateRequest request) 
        => customer.Create(request);

    [HttpPost]
    public CustomerReadResponse Read(CustomerReadRequest request) 
        => customer.Read(request);

    [HttpPost]
    public CustomerUpdateResponse Update(CustomerUpdateRequest request) 
        => customer.Update(request);

    [HttpPost]
    public CustomerDeleteResponse Delete(CustomerDeleteRequest request) 
        => customer.Delete(request);

    [HttpPost]
    public CustomerListResponse List(CustomerListRequest request) 
        => customer.List(request);
}
