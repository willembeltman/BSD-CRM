using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CompanyCreateRequest : BaseRequest
{
    public Company Company { get; set; } = new Company();
}
