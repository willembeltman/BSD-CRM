using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ProjectCreateRequest : BaseRequest
{
    public Project Project { get; set; } = new Project();
}
