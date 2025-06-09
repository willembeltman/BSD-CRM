using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class ProjectUpdateRequest : Request
{
    public Project Project { get; set; } = new Project();
}
