using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyUserListResponse : BaseResponse
{
    public CompanyUser[] CompanyUsers { get; set; } = [];
}