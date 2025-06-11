using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class TaxRateProxy(HttpClient httpClient)
{
    public async Task<TaxRateCreateResponse> Create(TaxRateCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TaxRate/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TaxRateCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TaxRateReadResponse> Read(TaxRateReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TaxRate/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TaxRateReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TaxRateUpdateResponse> Update(TaxRateUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TaxRate/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TaxRateUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TaxRateDeleteResponse> Delete(TaxRateDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TaxRate/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TaxRateDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TaxRateListResponse> List(TaxRateListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/TaxRate/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TaxRateListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
