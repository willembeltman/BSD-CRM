using System.Net.Http.Json;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Proxy;

public class WorkorderProxy(HttpClient httpClient)
{
    public async Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/CreateAsync", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderReadResponse> ReadAsync(WorkorderReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/ReadAsync", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderUpdateResponse> UpdateAsync(WorkorderUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/UpdateAsync", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderDeleteResponse> DeleteAsync(WorkorderDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/DeleteAsync", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderListResponse> ListAsync(WorkorderListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/ListAsync", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
