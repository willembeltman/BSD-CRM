using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class UserProxy(HttpClient httpClient)
{
    public async Task<SetCurrentCompanyResponse> SetCurrentCompany(SetCurrentCompanyRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/SetCurrentCompany", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SetCurrentCompanyResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ReadKnownUserResponse> ReadKnownUser(ReadKnownUserRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/ReadKnownUser", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ReadKnownUserResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<UpdateMyselfResponse> UpdateMyself(UpdateMyselfRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/UpdateMyself", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<UpdateMyselfResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DeleteMyselfResponse> DeleteMyself(DeleteMyselfRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/DeleteMyself", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DeleteMyselfResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ListKnownUsersResponse> ListKnownUsers(ListKnownUsersRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/User/ListKnownUsers", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ListKnownUsersResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
