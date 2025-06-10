using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateWorkorderResponse : BaseResponse
{
    public Workorder? Workorder { get; set; }
}