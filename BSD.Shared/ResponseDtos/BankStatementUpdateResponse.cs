using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementUpdateResponse : BaseResponse
{
    public BankStatement? BankStatement { get; set; }
}