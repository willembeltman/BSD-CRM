using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class BankStatementUpdateRequest : BaseRequest
{
    public BankStatement BankStatement { get; set; } = new BankStatement();
}