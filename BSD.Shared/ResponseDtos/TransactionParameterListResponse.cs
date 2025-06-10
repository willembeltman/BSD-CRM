using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionParameterListResponse : BaseResponse
{
    public TransactionParameter[] TransactionParameters { get; set; } = [];
}