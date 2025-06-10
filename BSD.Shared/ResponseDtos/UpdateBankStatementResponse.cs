using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateBankStatementResponse : BaseResponse
{
    public BankStatement? BankStatement { get; set; }
}