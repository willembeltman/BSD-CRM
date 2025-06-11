using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class SupplierProxy(HttpClient httpClient)
{
    public async Task<SupplierCreateResponse> Create(SupplierCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Supplier/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SupplierCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SupplierReadResponse> Read(SupplierReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Supplier/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SupplierReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SupplierUpdateResponse> Update(SupplierUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Supplier/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SupplierUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SupplierDeleteResponse> Delete(SupplierDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Supplier/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SupplierDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<SupplierListResponse> List(SupplierListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Supplier/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<SupplierListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
