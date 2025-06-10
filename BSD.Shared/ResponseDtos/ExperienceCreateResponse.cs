using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceCreateResponse : BaseResponse
{
    public Experience? Experience { get; set; }
}