using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class BankStatementExpenseProxy(HttpClient httpClient)
{
    public async Task<BankStatementExpenseCreateResponse> Create(BankStatementExpenseCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementExpense/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementExpenseCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementExpenseReadResponse> Read(BankStatementExpenseReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementExpense/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementExpenseReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementExpenseUpdateResponse> Update(BankStatementExpenseUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementExpense/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementExpenseUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementExpenseDeleteResponse> Delete(BankStatementExpenseDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementExpense/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementExpenseDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementExpenseListResponse> List(BankStatementExpenseListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementExpense/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementExpenseListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
