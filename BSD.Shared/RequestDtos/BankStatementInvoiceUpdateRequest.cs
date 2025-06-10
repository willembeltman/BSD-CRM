using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementInvoiceUpdateRequest : BaseRequest
{
    public BankStatementInvoice BankStatementInvoice { get; set; } = new BankStatementInvoice();
}