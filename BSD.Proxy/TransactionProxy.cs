using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TransactionProxy(HttpClient httpClient)
{
    public async Task<TransactionCreateResponse> Create(TransactionCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Transaction/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionReadResponse> Read(TransactionReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Transaction/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionUpdateResponse> Update(TransactionUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Transaction/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionDeleteResponse> Delete(TransactionDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Transaction/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionListResponse> List(TransactionListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Transaction/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
