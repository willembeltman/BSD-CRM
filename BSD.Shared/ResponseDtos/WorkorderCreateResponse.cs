using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderCreateResponse : BaseResponse
{
    public Workorder? Workorder { get; set; }
}