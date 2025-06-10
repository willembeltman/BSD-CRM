using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentTypeCreateResponse : BaseResponse
{
    public DocumentType? DocumentType { get; set; }
}