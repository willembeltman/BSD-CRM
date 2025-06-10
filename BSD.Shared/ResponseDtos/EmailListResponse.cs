using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class EmailListResponse : BaseResponse
{
    public Email[] Emails { get; set; } = [];
}