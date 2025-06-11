using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class InvoicePriceProxy(HttpClient httpClient)
{
    public async Task<InvoicePriceCreateResponse> Create(InvoicePriceCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoicePrice/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoicePriceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoicePriceReadResponse> Read(InvoicePriceReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoicePrice/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoicePriceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoicePriceUpdateResponse> Update(InvoicePriceUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoicePrice/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoicePriceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoicePriceDeleteResponse> Delete(InvoicePriceDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoicePrice/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoicePriceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoicePriceListResponse> List(InvoicePriceListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoicePrice/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoicePriceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
