using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StorageServer.Proxy;
using StorageServer.Proxy.Actions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StorageServer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IOptions<AppConfig> config) : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var cred = config.Value.Credentials
            .FirstOrDefault(a => a.UserName == request.Username && a.Password == request.Password);

        if (cred != null)
        //if (request.Username == "server" && request.Password == "topgeheim")
        {
            //var key = Encoding.ASCII.GetBytes("ditIsEenSuperGeheimeSleutel123!!");

            var key = new SymmetricSecurityKey(config.Value.SuperSecretKeyArray);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { token = jwt });
        }

        return Unauthorized();
    }
}
