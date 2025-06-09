using System.Net.Http.Json;
using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Proxy;

public class CustomerProxy(HttpClient httpClient)
{
    public async Task<CustomerCreateResponse> Create(CustomerCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Customer/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CustomerCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CustomerReadResponse> Read(CustomerReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Customer/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CustomerReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CustomerUpdateResponse> Update(CustomerUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Customer/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CustomerUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CustomerDeleteResponse> Delete(CustomerDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Customer/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CustomerDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<CustomerListResponse> List(CustomerListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Customer/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CustomerListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
