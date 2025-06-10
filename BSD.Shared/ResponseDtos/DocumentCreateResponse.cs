using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentCreateResponse : BaseResponse
{
    public Document? Document { get; set; }
}