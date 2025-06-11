using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExpensePriceProxy(HttpClient httpClient)
{
    public async Task<ExpensePriceCreateResponse> Create(ExpensePriceCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpensePrice/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpensePriceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpensePriceReadResponse> Read(ExpensePriceReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpensePrice/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpensePriceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpensePriceUpdateResponse> Update(ExpensePriceUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpensePrice/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpensePriceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpensePriceDeleteResponse> Delete(ExpensePriceDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpensePrice/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpensePriceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpensePriceListResponse> List(ExpensePriceListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExpensePrice/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpensePriceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
