using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
using Microsoft.AspNetCore.Mvc;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IAuthenticationService AuthenticationService) : BaseControllerBase
{
    [HttpPost]
    public LoginResponse Login(LoginRequest request)
        => AuthenticationService.Login(request);

    [HttpPost]
    public RegisterResponse Register(RegisterRequest request)
        => AuthenticationService.Register(request);
}
