using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class BankStatementInvoiceProxy(HttpClient httpClient)
{
    public async Task<BankStatementInvoiceCreateResponse> Create(BankStatementInvoiceCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementInvoice/Create", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementInvoiceCreateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementInvoiceReadResponse> Read(BankStatementInvoiceReadRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementInvoice/Read", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementInvoiceReadResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementInvoiceUpdateResponse> Update(BankStatementInvoiceUpdateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementInvoice/Update", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementInvoiceUpdateResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementInvoiceDeleteResponse> Delete(BankStatementInvoiceDeleteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementInvoice/Delete", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementInvoiceDeleteResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<BankStatementInvoiceListResponse> List(BankStatementInvoiceListRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/BankStatementInvoice/List", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<BankStatementInvoiceListResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
