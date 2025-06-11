using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExpenseProductProxy(HttpClient httpClient)
{
    public async Task<ExpenseProductCreateResponse> Create(ExpenseProductCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseProduct/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseProductCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseProductReadResponse> Read(ExpenseProductReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseProduct/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseProductReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseProductUpdateResponse> Update(ExpenseProductUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseProduct/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseProductUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseProductDeleteResponse> Delete(ExpenseProductDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseProduct/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseProductDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseProductListResponse> List(ExpenseProductListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseProduct/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseProductListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
