using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CountryReadResponse : BaseResponse
{
    public Country? Country { get; set; }
}