using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class CountryProxy(HttpClient httpClient)
{
    public async Task<CountryCreateResponse> Create(CountryCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Country/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CountryReadResponse> Read(CountryReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Country/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CountryUpdateResponse> Update(CountryUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Country/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CountryDeleteResponse> Delete(CountryDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Country/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CountryListResponse> List(CountryListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Country/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
