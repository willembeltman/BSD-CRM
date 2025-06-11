using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class DocumentAttachmentProxy(HttpClient httpClient)
{
    public async Task<DocumentAttachmentCreateResponse> Create(DocumentAttachmentCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentAttachmentReadResponse> Read(DocumentAttachmentReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentAttachmentUpdateResponse> Update(DocumentAttachmentUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentAttachmentDeleteResponse> Delete(DocumentAttachmentDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<DocumentAttachmentListResponse> List(DocumentAttachmentListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/DocumentAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<DocumentAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
