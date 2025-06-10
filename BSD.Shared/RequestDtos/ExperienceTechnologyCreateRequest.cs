using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExperienceTechnologyCreateRequest : BaseRequest
{
    public ExperienceTechnology ExperienceTechnology { get; set; } = new ExperienceTechnology();
}