using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentUpdateResponse : BaseResponse
{
    public Document? Document { get; set; }
}