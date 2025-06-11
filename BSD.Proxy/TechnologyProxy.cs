using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TechnologyProxy(HttpClient httpClient)
{
    public async Task<TechnologyCreateResponse> Create(TechnologyCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Technology/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyReadResponse> Read(TechnologyReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Technology/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyUpdateResponse> Update(TechnologyUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Technology/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyDeleteResponse> Delete(TechnologyDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Technology/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyListResponse> List(TechnologyListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Technology/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
