using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TransactionParameterProxy(HttpClient httpClient)
{
    public async Task<TransactionParameterCreateResponse> Create(TransactionParameterCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionParameter/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionParameterCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionParameterReadResponse> Read(TransactionParameterReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionParameter/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionParameterReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionParameterUpdateResponse> Update(TransactionParameterUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionParameter/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionParameterUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionParameterDeleteResponse> Delete(TransactionParameterDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionParameter/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionParameterDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TransactionParameterListResponse> List(TransactionParameterListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TransactionParameter/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TransactionParameterListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
