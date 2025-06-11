using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class WorkorderProxy(HttpClient httpClient)
{
    public async Task<WorkorderCreateResponse> Create(WorkorderCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderReadResponse> Read(WorkorderReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderUpdateResponse> Update(WorkorderUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderDeleteResponse> Delete(WorkorderDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderListResponse> List(WorkorderListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Workorder/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
