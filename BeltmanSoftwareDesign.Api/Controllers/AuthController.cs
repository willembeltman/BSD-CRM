using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IAuthenticationService authentication) : ControllerBase
{
    [HttpPost]
    public LoginResponse Login(LoginRequest request) 
        => authentication.Login(request);

    [HttpPost]
    public RegisterResponse Register(RegisterRequest request) 
        => authentication.Register(request);
}
