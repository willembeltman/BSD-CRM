using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CustomerController(ICustomer Customer) : BaseControllerBase
{
    [HttpPost]
    public CustomerCreateResponse Create(CustomerCreateRequest request) 
        => Customer.Create(request);

    [HttpPost]
    public CustomerReadResponse Read(CustomerReadRequest request) 
        => Customer.Read(request);

    [HttpPost]
    public CustomerUpdateResponse Update(CustomerUpdateRequest request) 
        => Customer.Update(request);

    [HttpPost]
    public CustomerDeleteResponse Delete(CustomerDeleteRequest request) 
        => Customer.Delete(request);

    [HttpPost]
    public CustomerListResponse List(CustomerListRequest request) 
        => Customer.List(request);
}
