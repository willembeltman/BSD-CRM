using Microsoft.AspNetCore.Mvc;

namespace StorageServer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentController : ControllerBase
{
    // GET /Content/{*path}?token=...
    [HttpGet("{*path}")]
    public IActionResult GetFile(string path, [FromQuery] string token)
    {


        // path = "TestPath/Test.txt"
        // token = "0123456789ABCDEF"

        // Hier kun je token valideren

        // Bijvoorbeeld: checken of token geldig is

        if (string.IsNullOrEmpty(token) || token != "0123456789ABCDEF")
        {
            return Unauthorized("Invalid token");
        }

        // Gebruik path om het bestand op te halen, bv:
        // var fileStream = storageService.GetFileStream(path);
        // if fileStream == null return NotFound();

        // return File(fileStream, contentType, Path.GetFileName(path));

        return Ok($"You requested file at path '{path}' with token '{token}'");
    }
}

