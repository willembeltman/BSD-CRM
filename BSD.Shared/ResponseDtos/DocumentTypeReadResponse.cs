using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentTypeReadResponse : BaseResponse
{
    public DocumentType? DocumentType { get; set; }
}