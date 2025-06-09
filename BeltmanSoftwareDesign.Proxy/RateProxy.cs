using System.Net.Http.Json;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Proxy;

public class RateProxy(HttpClient httpClient)
{
    public async Task<RateCreateResponse> Create(RateCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Rate/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RateCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<RateReadResponse> Read(RateReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Rate/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RateReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<RateUpdateResponse> Update(RateUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Rate/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RateUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<RateDeleteResponse> Delete(RateDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Rate/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RateDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<RateListResponse> List(RateListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Rate/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RateListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
