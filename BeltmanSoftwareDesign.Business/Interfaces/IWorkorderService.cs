using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Business.Interfaces
{
    public interface IWorkorderService
    {
        Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers);
        Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers);
        Task<WorkorderListResponse> ListAsync(WorkorderListRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers);
        Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers);
        Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request, string? ipAddress, KeyValuePair<string, string?>[]? headers);
    }
}
