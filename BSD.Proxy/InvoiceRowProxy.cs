using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class InvoiceRowProxy(HttpClient httpClient)
{
    public async Task<InvoiceRowCreateResponse> Create(InvoiceRowCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceRow/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceRowCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceRowReadResponse> Read(InvoiceRowReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceRow/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceRowReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceRowUpdateResponse> Update(InvoiceRowUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceRow/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceRowUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceRowDeleteResponse> Delete(InvoiceRowDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceRow/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceRowDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceRowListResponse> List(InvoiceRowListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceRow/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceRowListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
