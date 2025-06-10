using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceListResponse : BaseResponse
{
    public Experience[] Experiences { get; set; } = [];
}