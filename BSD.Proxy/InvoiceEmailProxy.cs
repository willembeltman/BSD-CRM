using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class InvoiceEmailProxy(HttpClient httpClient)
{
    public async Task<InvoiceEmailCreateResponse> Create(InvoiceEmailCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceEmail/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceEmailCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceEmailReadResponse> Read(InvoiceEmailReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceEmail/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceEmailReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceEmailUpdateResponse> Update(InvoiceEmailUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceEmail/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceEmailUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceEmailDeleteResponse> Delete(InvoiceEmailDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceEmail/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceEmailDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceEmailListResponse> List(InvoiceEmailListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceEmail/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceEmailListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
