using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class InvoiceProductProxy(HttpClient httpClient)
{
    public async Task<InvoiceProductCreateResponse> Create(InvoiceProductCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceProduct/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceProductCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceProductReadResponse> Read(InvoiceProductReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceProduct/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceProductReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceProductUpdateResponse> Update(InvoiceProductUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceProduct/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceProductUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceProductDeleteResponse> Delete(InvoiceProductDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceProduct/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceProductDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceProductListResponse> List(InvoiceProductListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceProduct/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceProductListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
