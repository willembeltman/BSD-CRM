using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class ExperienceAttachmentProxy(HttpClient httpClient)
{
    public async Task<ExperienceAttachmentCreateResponse> Create(ExperienceAttachmentCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceAttachmentReadResponse> Read(ExperienceAttachmentReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceAttachmentUpdateResponse> Update(ExperienceAttachmentUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceAttachmentDeleteResponse> Delete(ExperienceAttachmentDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExperienceAttachmentListResponse> List(ExperienceAttachmentListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/ExperienceAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExperienceAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
