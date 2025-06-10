using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementInvoiceCreateResponse : BaseResponse
{
    public BankStatementInvoice? BankStatementInvoice { get; set; }
}