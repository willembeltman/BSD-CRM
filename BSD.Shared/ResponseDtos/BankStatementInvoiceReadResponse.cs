using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementInvoiceReadResponse : BaseResponse
{
    public BankStatementInvoice? BankStatementInvoice { get; set; }
}