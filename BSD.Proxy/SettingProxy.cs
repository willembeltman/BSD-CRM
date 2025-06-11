using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class SettingProxy(HttpClient httpClient)
{
    public async Task<SettingCreateResponse> Create(SettingCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Setting/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SettingCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SettingReadResponse> Read(SettingReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Setting/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SettingReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SettingUpdateResponse> Update(SettingUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Setting/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SettingUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SettingDeleteResponse> Delete(SettingDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Setting/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SettingDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SettingListResponse> List(SettingListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Setting/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SettingListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
