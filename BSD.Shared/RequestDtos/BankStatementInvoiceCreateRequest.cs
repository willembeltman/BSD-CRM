using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementInvoiceCreateRequest : BaseRequest
{
    public BankStatementInvoice BankStatementInvoice { get; set; } = new BankStatementInvoice();
}