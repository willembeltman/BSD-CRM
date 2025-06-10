using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProjectCreateResponse : BaseResponse
{
    public Project? Project { get; set; }
}