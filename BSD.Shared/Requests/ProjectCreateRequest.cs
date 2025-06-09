using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class ProjectCreateRequest : Request
{
    public Project Project { get; set; } = new Project();
}
