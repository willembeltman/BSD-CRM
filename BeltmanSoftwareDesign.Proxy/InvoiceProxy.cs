using System.Net.Http.Json;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Proxy;

public class InvoiceProxy(HttpClient httpClient)
{
    public async Task<InvoiceCreateResponse> Create(InvoiceCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Invoice/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceReadResponse> Read(InvoiceReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Invoice/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceUpdateResponse> Update(InvoiceUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Invoice/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceDeleteResponse> Delete(InvoiceDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Invoice/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceListResponse> List(InvoiceListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Invoice/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
