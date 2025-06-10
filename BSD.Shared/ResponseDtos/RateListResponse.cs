using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class RateListResponse : BaseResponse
{
    public Rate[] Rates { get; set; } = [];
}