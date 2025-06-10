using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementCreateRequest : BaseRequest
{
    public BankStatement BankStatement { get; set; } = new BankStatement();
}