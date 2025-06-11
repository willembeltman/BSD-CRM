using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExperienceTechnologyProxy(HttpClient httpClient)
{
    public async Task<ExperienceTechnologyCreateResponse> Create(ExperienceTechnologyCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceTechnology/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceTechnologyCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceTechnologyReadResponse> Read(ExperienceTechnologyReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceTechnology/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceTechnologyReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceTechnologyUpdateResponse> Update(ExperienceTechnologyUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceTechnology/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceTechnologyUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceTechnologyDeleteResponse> Delete(ExperienceTechnologyDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceTechnology/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceTechnologyDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceTechnologyListResponse> List(ExperienceTechnologyListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceTechnology/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceTechnologyListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
