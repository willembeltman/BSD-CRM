using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CompanyUserCreateRequest : BaseRequest
{
    public CompanyUser CompanyUser { get; set; } = new CompanyUser();
}