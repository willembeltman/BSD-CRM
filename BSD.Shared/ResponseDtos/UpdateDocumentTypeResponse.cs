using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateDocumentTypeResponse : BaseResponse
{
    public DocumentType? DocumentType { get; set; }
}