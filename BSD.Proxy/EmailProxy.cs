using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class EmailProxy(HttpClient httpClient)
{
    public async Task<EmailCreateResponse> Create(EmailCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Email/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<EmailCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<EmailReadResponse> Read(EmailReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Email/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<EmailReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<EmailUpdateResponse> Update(EmailUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Email/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<EmailUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<EmailDeleteResponse> Delete(EmailDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Email/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<EmailDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<EmailListResponse> List(EmailListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Email/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<EmailListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
