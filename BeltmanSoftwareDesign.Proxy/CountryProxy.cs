using System.Net.Http.Json;
using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Proxy;

public class CountryProxy(HttpClient httpClient)
{
    public async Task<CountryListResponse> List(CountryListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Country/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<CountryListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
