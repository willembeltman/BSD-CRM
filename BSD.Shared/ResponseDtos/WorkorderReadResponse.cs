using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderReadResponse : BaseResponse
{
    public Workorder? Workorder { get; set; }
}