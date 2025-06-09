using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService user) : ControllerBase
{
    [HttpPost]
    public SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request) 
        => user.SetCurrentCompany(request);

    [HttpPost]
    public ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request) 
        => user.ReadKnownUser(request);

    [HttpPost]
    public UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request) 
        => user.UpdateMyself(request);

    [HttpPost]
    public DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request) 
        => user.DeleteMyself(request);

    [HttpPost]
    public ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request) 
        => user.ListKnownUsers(request);
}
