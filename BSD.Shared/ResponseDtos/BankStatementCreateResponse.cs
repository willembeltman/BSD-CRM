using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementCreateResponse : BaseResponse
{
    public BankStatement? BankStatement { get; set; }
}