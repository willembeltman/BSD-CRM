using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class BankStatementProxy(HttpClient httpClient)
{
    public async Task<BankStatementCreateResponse> Create(BankStatementCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatement/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementReadResponse> Read(BankStatementReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatement/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementUpdateResponse> Update(BankStatementUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatement/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementDeleteResponse> Delete(BankStatementDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatement/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementListResponse> List(BankStatementListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatement/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
