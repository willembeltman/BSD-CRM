using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ResidenceCreateResponse : BaseResponse
{
    public Residence? Residence { get; set; }
}