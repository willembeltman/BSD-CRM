using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementInvoiceListResponse : BaseResponse
{
    public BankStatementInvoice[] BankStatementInvoices { get; set; } = [];
}