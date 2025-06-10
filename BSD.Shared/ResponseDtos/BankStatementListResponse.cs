using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class BankStatementListResponse : BaseResponse
{
    public BankStatement[] BankStatements { get; set; } = [];
}