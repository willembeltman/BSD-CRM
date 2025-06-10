using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class TechnologyUpdateRequest : BaseRequest
{
    public Technology Technology { get; set; } = new Technology();
}