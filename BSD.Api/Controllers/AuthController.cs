using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

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

    [HttpPost]
    public ForgotPasswordResponse ForgotPassword(ForgotPasswordRequest request) 
        => authentication.ForgotPassword(request);
}
