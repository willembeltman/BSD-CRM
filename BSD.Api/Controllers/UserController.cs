using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService user) : ControllerBase
{
    [HttpPost]
    public UserCreateResponse Create(UserCreateRequest request)
        => user.Create(request);

    [HttpPost]
    public UserReadResponse Read(UserReadRequest request)
        => user.Read(request);

    [HttpPost]
    public UserUpdateResponse Update(UserUpdateRequest request)
        => user.Update(request);

    [HttpPost]
    public UserDeleteResponse Delete(UserDeleteRequest request)
        => user.Delete(request);

    [HttpPost]
    public UserListResponse List(UserListRequest request)
        => user.List(request);
}
