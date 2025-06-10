using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentTypeUpdateResponse : BaseResponse
{
    public DocumentType? DocumentType { get; set; }
}