using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExperienceTechnologyResponse : BaseResponse
{
    public ExperienceTechnology? ExperienceTechnology { get; set; }
}