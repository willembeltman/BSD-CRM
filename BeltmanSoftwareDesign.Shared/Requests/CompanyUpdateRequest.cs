using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class CompanyUpdateRequest : Request
{
    public Company Company { get; set; } = new Company();
}
