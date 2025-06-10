using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceCreateRequest : BaseRequest
{
    public Experience Experience { get; set; } = new Experience();
}