using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentListResponse : BaseResponse
{
    public Document[] Documents { get; set; } = [];
}