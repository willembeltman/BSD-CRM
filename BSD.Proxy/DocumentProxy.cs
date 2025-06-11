using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class DocumentProxy(HttpClient httpClient)
{
    public async Task<DocumentCreateResponse> Create(DocumentCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Document/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentReadResponse> Read(DocumentReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Document/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentUpdateResponse> Update(DocumentUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Document/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentDeleteResponse> Delete(DocumentDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Document/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentListResponse> List(DocumentListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/Document/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
