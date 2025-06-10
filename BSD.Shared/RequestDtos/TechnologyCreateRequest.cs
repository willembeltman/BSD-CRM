using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TechnologyCreateRequest : BaseRequest
{
    public Technology Technology { get; set; } = new Technology();
}