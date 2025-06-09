using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUser User) : BaseControllerBase
{
    [HttpPost]
    public SetCurrentCompanyResponse SetCurrentCompany(SetCurrentCompanyRequest request) 
        => User.SetCurrentCompany(request);

    [HttpPost]
    public ReadKnownUserResponse ReadKnownUser(ReadKnownUserRequest request) 
        => User.ReadKnownUser(request);

    [HttpPost]
    public UpdateMyselfResponse UpdateMyself(UpdateMyselfRequest request) 
        => User.UpdateMyself(request);

    [HttpPost]
    public DeleteMyselfResponse DeleteMyself(DeleteMyselfRequest request) 
        => User.DeleteMyself(request);

    [HttpPost]
    public ListKnownUsersResponse ListKnownUsers(ListKnownUsersRequest request) 
        => User.ListKnownUsers(request);
}
