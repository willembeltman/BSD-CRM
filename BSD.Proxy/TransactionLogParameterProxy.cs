using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TransactionLogParameterProxy(HttpClient httpClient)
{
    public async Task<TransactionLogParameterCreateResponse> Create(TransactionLogParameterCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLogParameter/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogParameterCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogParameterReadResponse> Read(TransactionLogParameterReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLogParameter/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogParameterReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogParameterUpdateResponse> Update(TransactionLogParameterUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLogParameter/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogParameterUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogParameterDeleteResponse> Delete(TransactionLogParameterDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLogParameter/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogParameterDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionLogParameterListResponse> List(TransactionLogParameterListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionLogParameter/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionLogParameterListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
