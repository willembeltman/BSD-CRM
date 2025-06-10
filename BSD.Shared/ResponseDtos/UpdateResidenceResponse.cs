using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateResidenceResponse : BaseResponse
{
    public Residence? Residence { get; set; }
}