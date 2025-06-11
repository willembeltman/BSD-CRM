using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class DocumentTypeProxy(HttpClient httpClient)
{
    public async Task<DocumentTypeCreateResponse> Create(DocumentTypeCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentType/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentTypeCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentTypeReadResponse> Read(DocumentTypeReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentType/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentTypeReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentTypeUpdateResponse> Update(DocumentTypeUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentType/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentTypeUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentTypeDeleteResponse> Delete(DocumentTypeDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentType/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentTypeDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentTypeListResponse> List(DocumentTypeListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentType/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentTypeListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
