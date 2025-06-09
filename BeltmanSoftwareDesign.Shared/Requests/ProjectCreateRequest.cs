using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class ProjectCreateRequest : Request
{
    public Project Project { get; set; } = new Project();
}
