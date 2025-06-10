using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentReadResponse : BaseResponse
{
    public Document? Document { get; set; }
}