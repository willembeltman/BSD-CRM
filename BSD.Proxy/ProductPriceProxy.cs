using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class ProductPriceProxy(HttpClient httpClient)
{
    public async Task<ProductPriceCreateResponse> Create(ProductPriceCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ProductPrice/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductPriceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductPriceReadResponse> Read(ProductPriceReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ProductPrice/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductPriceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductPriceUpdateResponse> Update(ProductPriceUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ProductPrice/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductPriceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductPriceDeleteResponse> Delete(ProductPriceDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ProductPrice/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductPriceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ProductPriceListResponse> List(ProductPriceListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ProductPrice/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ProductPriceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
