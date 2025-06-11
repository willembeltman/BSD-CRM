using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class TechnologyAttachmentProxy(HttpClient httpClient)
{
    public async Task<TechnologyAttachmentCreateResponse> Create(TechnologyAttachmentCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/TechnologyAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyAttachmentReadResponse> Read(TechnologyAttachmentReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/TechnologyAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyAttachmentUpdateResponse> Update(TechnologyAttachmentUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/TechnologyAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyAttachmentDeleteResponse> Delete(TechnologyAttachmentDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/TechnologyAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<TechnologyAttachmentListResponse> List(TechnologyAttachmentListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/TechnologyAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<TechnologyAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
