using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyUserCreateResponse : BaseResponse
{
    public CompanyUser? CompanyUser { get; set; }
}