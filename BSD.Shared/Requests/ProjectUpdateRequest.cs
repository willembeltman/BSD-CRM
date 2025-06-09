using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class ProjectUpdateRequest : Request
{
    public Project Project { get; set; } = new Project();
}
