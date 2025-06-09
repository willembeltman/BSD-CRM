using BSD.Shared.Dtos;

namespace BSD.Shared.Requests;

public class CompanyUpdateRequest : Request
{
    public Company Company { get; set; } = new Company();
}
