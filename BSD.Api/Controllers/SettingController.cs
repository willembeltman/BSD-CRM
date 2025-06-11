using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SettingController(ISettingService setting) : ControllerBase
{
    [HttpPost]
    public SettingCreateResponse Create(SettingCreateRequest request) 
        => setting.Create(request);

    [HttpPost]
    public SettingReadResponse Read(SettingReadRequest request) 
        => setting.Read(request);

    [HttpPost]
    public SettingUpdateResponse Update(SettingUpdateRequest request) 
        => setting.Update(request);

    [HttpPost]
    public SettingDeleteResponse Delete(SettingDeleteRequest request) 
        => setting.Delete(request);

    [HttpPost]
    public SettingListResponse List(SettingListRequest request) 
        => setting.List(request);
}
