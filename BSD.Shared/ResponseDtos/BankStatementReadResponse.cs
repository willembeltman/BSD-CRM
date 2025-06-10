using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementReadResponse : BaseResponse
{
    public BankStatement? BankStatement { get; set; }
}