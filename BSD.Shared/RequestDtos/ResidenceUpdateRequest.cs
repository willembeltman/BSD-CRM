using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ResidenceUpdateRequest : BaseRequest
{
    public Residence Residence { get; set; } = new Residence();
}