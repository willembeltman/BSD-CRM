using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ProjectUpdateResponse : BaseResponse
{
    public Project? Project { get; set; }
}