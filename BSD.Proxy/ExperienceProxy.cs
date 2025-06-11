using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExperienceProxy(HttpClient httpClient)
{
    public async Task<ExperienceCreateResponse> Create(ExperienceCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Experience/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceReadResponse> Read(ExperienceReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Experience/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceUpdateResponse> Update(ExperienceUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Experience/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceDeleteResponse> Delete(ExperienceDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Experience/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceListResponse> List(ExperienceListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Experience/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
