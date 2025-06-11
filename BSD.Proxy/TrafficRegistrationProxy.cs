using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TrafficRegistrationProxy(HttpClient httpClient)
{
    public async Task<TrafficRegistrationCreateResponse> Create(TrafficRegistrationCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TrafficRegistration/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TrafficRegistrationCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TrafficRegistrationReadResponse> Read(TrafficRegistrationReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TrafficRegistration/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TrafficRegistrationReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TrafficRegistrationUpdateResponse> Update(TrafficRegistrationUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TrafficRegistration/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TrafficRegistrationUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TrafficRegistrationDeleteResponse> Delete(TrafficRegistrationDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TrafficRegistration/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TrafficRegistrationDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TrafficRegistrationListResponse> List(TrafficRegistrationListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TrafficRegistration/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TrafficRegistrationListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
