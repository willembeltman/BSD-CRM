using System.Net.Http.Json;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Proxy;

public class CompanyProxy(HttpClient httpClient)
{
    public async Task<CompanyCreateResponse> Create(CompanyCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Company/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyReadResponse> Read(CompanyReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Company/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyUpdateResponse> Update(CompanyUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Company/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyDeleteResponse> Delete(CompanyDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Company/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyListResponse> List(CompanyListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Company/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
