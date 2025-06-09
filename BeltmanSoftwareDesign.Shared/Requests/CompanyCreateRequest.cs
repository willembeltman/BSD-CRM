using BeltmanSoftwareDesign.Shared.Dtos;

namespace BeltmanSoftwareDesign.Shared.Requests;

public class CompanyCreateRequest : Request
{
    public Company Company { get; set; } = new Company();
}
