using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ProjectUpdateRequest : BaseRequest
{
    public Project Project { get; set; } = new Project();
}