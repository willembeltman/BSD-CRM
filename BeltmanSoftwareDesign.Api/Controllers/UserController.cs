using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService UserService) : BaseControllerBase
{
    [HttpPost]
    public SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request) 
        => UserService.SetCurrentCompany(request);

    [HttpPost]
    public ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request) 
        => UserService.ReadKnownUser(request);

    [HttpPost]
    public UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request) 
        => UserService.UpdateMyself(request);

    [HttpPost]
    public DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request) 
        => UserService.DeleteMyself(request);

    [HttpPost]
    public ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request) 
        => UserService.ListKnownUsers(request);
}
