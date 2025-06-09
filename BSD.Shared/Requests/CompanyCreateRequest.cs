using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class CompanyCreateRequest : Request
{
    public Company Company { get; set; } = new Company();
}
