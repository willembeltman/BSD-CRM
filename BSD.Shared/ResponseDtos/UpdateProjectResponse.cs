using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateProjectResponse : BaseResponse
{
    public Project? Project { get; set; }
}