using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateRateResponse : BaseResponse
{
    public Rate? Rate { get; set; }
}