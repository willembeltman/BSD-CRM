using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ResidenceReadResponse : BaseResponse
{
    public Residence? Residence { get; set; }
}