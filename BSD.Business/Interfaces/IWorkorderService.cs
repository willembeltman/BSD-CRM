using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface IWorkorderService
{
    Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request);
    Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request);
    Task<WorkorderListResponse> ListAsync(WorkorderListRequest request);
    Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request);
    Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request);
}
