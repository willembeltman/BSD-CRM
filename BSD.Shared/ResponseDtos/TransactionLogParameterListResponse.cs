using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class TransactionLogParameterListResponse : BaseResponse
{
    public TransactionLogParameter[] TransactionLogParameters { get; set; } = [];
}