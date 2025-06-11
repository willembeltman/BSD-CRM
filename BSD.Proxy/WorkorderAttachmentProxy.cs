using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class WorkorderAttachmentProxy(HttpClient httpClient)
{
    public async Task<WorkorderAttachmentCreateResponse> Create(WorkorderAttachmentCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/WorkorderAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderAttachmentReadResponse> Read(WorkorderAttachmentReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/WorkorderAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderAttachmentUpdateResponse> Update(WorkorderAttachmentUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/WorkorderAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderAttachmentDeleteResponse> Delete(WorkorderAttachmentDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/WorkorderAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<WorkorderAttachmentListResponse> List(WorkorderAttachmentListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/WorkorderAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<WorkorderAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
