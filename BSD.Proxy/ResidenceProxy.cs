using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ResidenceProxy(HttpClient httpClient)
{
    public async Task<ResidenceCreateResponse> Create(ResidenceCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Residence/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ResidenceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ResidenceReadResponse> Read(ResidenceReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Residence/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ResidenceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ResidenceUpdateResponse> Update(ResidenceUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Residence/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ResidenceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ResidenceDeleteResponse> Delete(ResidenceDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Residence/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ResidenceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ResidenceListResponse> List(ResidenceListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Residence/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ResidenceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
