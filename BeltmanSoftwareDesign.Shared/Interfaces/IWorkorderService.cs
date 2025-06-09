using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IWorkorderService
{
    Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request);
    Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request);
    Task<WorkorderListResponse> ListAsync(WorkorderListRequest request);
    Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request);
    Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request);
}
