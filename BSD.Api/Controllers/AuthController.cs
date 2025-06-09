using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Api.Controllers;

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
