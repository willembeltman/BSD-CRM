using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CompanyUpdateRequest : BaseRequest
{
    public Company Company { get; set; } = new Company();
}