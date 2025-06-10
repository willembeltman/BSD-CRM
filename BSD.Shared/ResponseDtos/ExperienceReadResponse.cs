using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceReadResponse : BaseResponse
{
    public Experience? Experience { get; set; }
}