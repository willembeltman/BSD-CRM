using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateDocumentResponse : BaseResponse
{
    public Document? Document { get; set; }
}