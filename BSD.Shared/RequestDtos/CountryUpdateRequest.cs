using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CountryUpdateRequest : BaseRequest
{
    public Country Country { get; set; } = new Country();
}