using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class InvoiceTransactionProxy(HttpClient httpClient)
{
    public async Task<InvoiceTransactionCreateResponse> Create(InvoiceTransactionCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceTransaction/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTransactionCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTransactionReadResponse> Read(InvoiceTransactionReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceTransaction/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTransactionReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTransactionUpdateResponse> Update(InvoiceTransactionUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceTransaction/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTransactionUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTransactionDeleteResponse> Delete(InvoiceTransactionDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceTransaction/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTransactionDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTransactionListResponse> List(InvoiceTransactionListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceTransaction/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTransactionListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
