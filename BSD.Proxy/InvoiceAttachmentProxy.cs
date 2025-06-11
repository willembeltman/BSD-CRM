using System.Net.Http.Json;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Proxy;

public class InvoiceAttachmentProxy(HttpClient httpClient)
{
    public async Task<InvoiceAttachmentCreateResponse> Create(InvoiceAttachmentCreateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceAttachment/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceAttachmentCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceAttachmentReadResponse> Read(InvoiceAttachmentReadRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceAttachment/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceAttachmentReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceAttachmentUpdateResponse> Update(InvoiceAttachmentUpdateRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceAttachment/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceAttachmentUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceAttachmentDeleteResponse> Delete(InvoiceAttachmentDeleteRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceAttachment/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceAttachmentDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<InvoiceAttachmentListResponse> List(InvoiceAttachmentListRequest request) 
    {
        var response = await httpClient.PostAsJsonAsync("/InvoiceAttachment/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<InvoiceAttachmentListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
