using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageServer.Business.Interfaces;
using StorageServer.Proxy.Actions;

namespace StorageServer.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class StorageController(IStorageService storageService) : ControllerBase
{
    [HttpPost]
    public async Task<GetUrlResponse> GetUrl(GetUrlRequest model)
    {
        return await storageService.GetUrlAsync(model);
    }

    [HttpPost]
    public async Task<ExistsResponse> Exists(ExistsRequest model)
    {
        return await storageService.ExistsAsync(model);
    }

    [HttpPost]
    public async Task<IActionResult> Open(OpenRequest model)
    {
        var response = await storageService.OpenAsync(model);
        if (response == null) throw new Exception("Could not open storage file");
        return File(response.Stream, response.MimeType, response.FileName);
    }

    [HttpPost]
    public async Task<SaveResponse> Save([FromForm] SaveRequest model, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return new SaveResponse { Success = false, Message = "No file uploaded" };

        var stream = file.OpenReadStream();
        return await storageService.SaveAsync(model, stream);
    }

    [HttpPost]
    public async Task<DeleteResponse> Delete(DeleteRequest model)
    {
        return await storageService.DeleteAsync(model);
    }
}
