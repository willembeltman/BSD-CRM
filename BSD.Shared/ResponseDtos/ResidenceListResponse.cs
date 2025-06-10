using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ResidenceListResponse : BaseResponse
{
    public Residence[] Residences { get; set; } = [];
}