using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class CompanyListResponse : BaseResponse
{
    public Company[] Companies { get; set; } = [];
}
