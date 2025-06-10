using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceUpdateRequest : BaseRequest
{
    public Experience Experience { get; set; } = new Experience();
}