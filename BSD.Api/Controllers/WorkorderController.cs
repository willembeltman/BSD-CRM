using Microsoft.AspNetCore.Mvc;
using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkorderController(IWorkorderService workorder) : ControllerBase
{
    [HttpPost]
    public async Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request) 
        => await workorder.CreateAsync(request);

    [HttpPost]
    public async Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request) 
        => await workorder.ReadAsync(request);

    [HttpPost]
    public async Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request) 
        => await workorder.UpdateAsync(request);

    [HttpPost]
    public async Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request) 
        => await workorder.DeleteAsync(request);

    [HttpPost]
    public async Task<WorkorderListResponse> ListAsync(WorkorderListRequest request) 
        => await workorder.ListAsync(request);
}
