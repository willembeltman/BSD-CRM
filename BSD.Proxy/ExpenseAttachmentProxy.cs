using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class ExpenseAttachmentProxy(HttpClient httpClient)
{
    public async Task<ExpenseAttachmentCreateResponse> Create(ExpenseAttachmentCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseAttachmentReadResponse> Read(ExpenseAttachmentReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseAttachmentUpdateResponse> Update(ExpenseAttachmentUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseAttachmentDeleteResponse> Delete(ExpenseAttachmentDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ExpenseAttachmentListResponse> List(ExpenseAttachmentListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/ExpenseAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ExpenseAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
