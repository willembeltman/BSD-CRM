using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExperienceResponse : BaseResponse
{
    public Experience? Experience { get; set; }
}