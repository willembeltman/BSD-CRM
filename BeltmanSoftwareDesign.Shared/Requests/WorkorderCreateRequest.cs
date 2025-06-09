using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class WorkorderCreateRequest : Request
{
    public Workorder Workorder { get; set; } = new Workorder();
}
