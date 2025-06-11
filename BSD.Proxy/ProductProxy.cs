using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ProductProxy(HttpClient httpClient)
{
    public async Task<ProductCreateResponse> Create(ProductCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Product/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductReadResponse> Read(ProductReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Product/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductUpdateResponse> Update(ProductUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Product/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductDeleteResponse> Delete(ProductDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Product/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductListResponse> List(ProductListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Product/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
