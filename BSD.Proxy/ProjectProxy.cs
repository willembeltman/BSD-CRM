using System.Net.Http.Json;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Proxy;

public class ProjectProxy(HttpClient httpClient)
{
    public async Task<ProjectCreateResponse> Create(ProjectCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Project/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProjectCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProjectReadResponse> Read(ProjectReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Project/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProjectReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProjectUpdateResponse> Update(ProjectUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Project/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProjectUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProjectDeleteResponse> Delete(ProjectDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Project/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProjectDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProjectListResponse> List(ProjectListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Project/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProjectListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
