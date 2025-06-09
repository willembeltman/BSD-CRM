using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class RateCreateRequest : Request
{
    public Rate Rate { get; set; } = new Rate();
}
