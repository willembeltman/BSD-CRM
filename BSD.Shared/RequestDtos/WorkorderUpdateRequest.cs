using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class WorkorderUpdateRequest : BaseRequest
{
    public Workorder Workorder { get; set; } = new Workorder();
}