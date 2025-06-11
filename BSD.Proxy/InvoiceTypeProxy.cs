using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class InvoiceTypeProxy(HttpClient httpClient)
{
    public async Task<InvoiceTypeCreateResponse> Create(InvoiceTypeCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceType/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTypeCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTypeReadResponse> Read(InvoiceTypeReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceType/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTypeReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTypeUpdateResponse> Update(InvoiceTypeUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceType/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTypeUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTypeDeleteResponse> Delete(InvoiceTypeDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceType/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTypeDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceTypeListResponse> List(InvoiceTypeListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceType/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceTypeListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
