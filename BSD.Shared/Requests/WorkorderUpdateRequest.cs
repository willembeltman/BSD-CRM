using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class WorkorderUpdateRequest : Request
{
    public Workorder Workorder { get; set; } = new Workorder();
}
