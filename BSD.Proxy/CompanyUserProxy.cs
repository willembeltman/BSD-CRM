using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class CompanyUserProxy(HttpClient httpClient)
{
    public async Task<CompanyUserCreateResponse> Create(CompanyUserCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/CompanyUser/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUserCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyUserReadResponse> Read(CompanyUserReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/CompanyUser/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUserReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyUserUpdateResponse> Update(CompanyUserUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/CompanyUser/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUserUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyUserDeleteResponse> Delete(CompanyUserDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/CompanyUser/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUserDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CompanyUserListResponse> List(CompanyUserListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/CompanyUser/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CompanyUserListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
