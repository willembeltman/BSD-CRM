using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class WorkorderUpdateRequest : Request
{
    public Workorder Workorder { get; set; } = new Workorder();
}
