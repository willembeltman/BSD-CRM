using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class RateUpdateRequest : Request
{
    public Rate Rate { get; set; } = new Rate();
}
