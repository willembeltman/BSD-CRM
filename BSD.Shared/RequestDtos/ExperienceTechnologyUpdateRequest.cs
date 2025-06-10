using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceTechnologyUpdateRequest : BaseRequest
{
    public ExperienceTechnology ExperienceTechnology { get; set; } = new ExperienceTechnology();
}