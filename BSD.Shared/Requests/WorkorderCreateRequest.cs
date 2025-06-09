using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class WorkorderCreateRequest : Request
{
    public Workorder Workorder { get; set; } = new Workorder();
}
