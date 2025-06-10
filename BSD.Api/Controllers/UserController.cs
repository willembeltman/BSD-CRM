using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

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
