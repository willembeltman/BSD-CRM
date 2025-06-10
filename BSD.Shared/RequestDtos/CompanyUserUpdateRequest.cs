using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class CompanyUserUpdateRequest : BaseRequest
{
    public CompanyUser CompanyUser { get; set; } = new CompanyUser();
}