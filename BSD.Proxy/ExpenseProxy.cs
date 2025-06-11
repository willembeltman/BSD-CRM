using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExpenseProxy(HttpClient httpClient)
{
    public async Task<ExpenseCreateResponse> Create(ExpenseCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Expense/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseReadResponse> Read(ExpenseReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Expense/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseUpdateResponse> Update(ExpenseUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Expense/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseDeleteResponse> Delete(ExpenseDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Expense/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseListResponse> List(ExpenseListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Expense/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
