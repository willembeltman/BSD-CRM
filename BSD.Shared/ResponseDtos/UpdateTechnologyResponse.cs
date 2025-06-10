using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateTechnologyResponse : BaseResponse
{
    public Technology? Technology { get; set; }
}