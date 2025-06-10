using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CountryUpdateResponse : BaseResponse
{
    public Country? Country { get; set; }
}