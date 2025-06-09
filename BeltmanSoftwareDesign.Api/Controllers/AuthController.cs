using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IAuthentication Authentication) : BaseControllerBase
{
    [HttpPost]
    public LoginResponse Login(LoginRequest request) 
        => Authentication.Login(request);

    [HttpPost]
    public RegisterResponse Register(RegisterRequest request) 
        => Authentication.Register(request);
}
