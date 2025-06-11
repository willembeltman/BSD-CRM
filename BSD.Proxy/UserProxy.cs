using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class UserProxy(HttpClient httpClient)
{
    public async Task<UserCreateResponse> Create(UserCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UserCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<UserReadResponse> Read(UserReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UserReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<UserUpdateResponse> Update(UserUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UserUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<UserDeleteResponse> Delete(UserDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UserDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<UserListResponse> List(UserListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UserListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
