using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExpenseTypeProxy(HttpClient httpClient)
{
    public async Task<ExpenseTypeCreateResponse> Create(ExpenseTypeCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseType/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseTypeCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseTypeReadResponse> Read(ExpenseTypeReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseType/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseTypeReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseTypeUpdateResponse> Update(ExpenseTypeUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseType/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseTypeUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseTypeDeleteResponse> Delete(ExpenseTypeDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseType/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseTypeDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseTypeListResponse> List(ExpenseTypeListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseType/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseTypeListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
