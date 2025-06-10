using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CountryCreateResponse : BaseResponse
{
    public Country? Country { get; set; }
}