using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateCountryResponse : BaseResponse
{
    public Country? Country { get; set; }
}