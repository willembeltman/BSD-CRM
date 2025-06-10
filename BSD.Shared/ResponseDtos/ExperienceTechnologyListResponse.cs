using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExperienceTechnologyListResponse : BaseResponse
{
    public ExperienceTechnology[] ExperienceTechnologys { get; set; } = [];
}