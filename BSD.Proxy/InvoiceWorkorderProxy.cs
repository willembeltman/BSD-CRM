using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class InvoiceWorkorderProxy(HttpClient httpClient)
{
    public async Task<InvoiceWorkorderCreateResponse> Create(InvoiceWorkorderCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceWorkorder/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceWorkorderCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceWorkorderReadResponse> Read(InvoiceWorkorderReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceWorkorder/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceWorkorderReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceWorkorderUpdateResponse> Update(InvoiceWorkorderUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceWorkorder/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceWorkorderUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceWorkorderDeleteResponse> Delete(InvoiceWorkorderDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceWorkorder/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceWorkorderDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceWorkorderListResponse> List(InvoiceWorkorderListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceWorkorder/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceWorkorderListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
