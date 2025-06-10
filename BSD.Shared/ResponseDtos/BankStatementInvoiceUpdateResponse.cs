using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementInvoiceUpdateResponse : BaseResponse
{
    public BankStatementInvoice? BankStatementInvoice { get; set; }
}