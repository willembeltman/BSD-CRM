using Microsoft.AspNetCore.Mvc;
using BeltmanSoftwareDesign.Business.Interfaces;
using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;
namespace BeltmanSoftwareDesign.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WorkorderController : BaseControllerBase
    {
        public WorkorderController(IWorkorderService workorderService) 
        {
            WorkorderService = workorderService;
        }

        public IWorkorderService WorkorderService { get; }

        [HttpPost]
        public async Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request) 
            => await WorkorderService.CreateAsync(request, IpAddress, Headers);

        [HttpPost]
        public async Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request) 
            => await WorkorderService.ReadAsync(request, IpAddress, Headers);

        [HttpPost]
        public async Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request) 
            => await WorkorderService.UpdateAsync(request, IpAddress, Headers);

        [HttpPost]
        public async Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request) 
            => await WorkorderService.DeleteAsync(request, IpAddress, Headers);

        [HttpPost]
        public async Task<WorkorderListResponse> ListAsync(WorkorderListRequest request) 
            => await WorkorderService.ListAsync(request, IpAddress, Headers);
    }
}
