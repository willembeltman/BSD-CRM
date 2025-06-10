using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ResidenceCreateRequest : BaseRequest
{
    public Residence Residence { get; set; } = new Residence();
}