using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceUpdateResponse : BaseResponse
{
    public Experience? Experience { get; set; }
}