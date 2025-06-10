using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CountryListResponse : BaseResponse
{
    public Country[] Countrys { get; set; } = [];
}