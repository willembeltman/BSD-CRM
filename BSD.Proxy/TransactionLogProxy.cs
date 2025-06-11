using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TransactionLogProxy(HttpClient httpClient)
{
    public async Task<TransactionLogCreateResponse> Create(TransactionLogCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLog/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogReadResponse> Read(TransactionLogReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLog/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogUpdateResponse> Update(TransactionLogUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLog/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogDeleteResponse> Delete(TransactionLogDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLog/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogListResponse> List(TransactionLogListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLog/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
