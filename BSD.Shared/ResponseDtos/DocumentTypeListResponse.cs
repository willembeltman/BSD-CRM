using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class DocumentTypeListResponse : BaseResponse
{
    public DocumentType[] DocumentTypes { get; set; } = [];
}