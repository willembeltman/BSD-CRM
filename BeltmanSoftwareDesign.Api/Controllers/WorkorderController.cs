using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Shared.Interfaces;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WorkorderController(IWorkorderService WorkorderService) : BaseControllerBase
{
    [HttpPost]
    public async Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request) 
        => await WorkorderService.CreateAsync(request);

    [HttpPost]
    public async Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request) 
        => await WorkorderService.ReadAsync(request);

    [HttpPost]
    public async Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request) 
        => await WorkorderService.UpdateAsync(request);

    [HttpPost]
    public async Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request) 
        => await WorkorderService.DeleteAsync(request);

    [HttpPost]
    public async Task<WorkorderListResponse> ListAsync(WorkorderListRequest request) 
        => await WorkorderService.ListAsync(request);
}
