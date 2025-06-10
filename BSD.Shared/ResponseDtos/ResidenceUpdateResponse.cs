using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ResidenceUpdateResponse : BaseResponse
{
    public Residence? Residence { get; set; }
}