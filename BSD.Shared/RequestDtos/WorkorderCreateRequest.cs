using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class WorkorderCreateRequest : BaseRequest
{
    public Workorder Workorder { get; set; } = new Workorder();
}
