using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CountryCreateRequest : BaseRequest
{
    public Country Country { get; set; } = new Country();
}