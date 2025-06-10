using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateBankStatementInvoiceResponse : BaseResponse
{
    public BankStatementInvoice? BankStatementInvoice { get; set; }
}