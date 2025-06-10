using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class DocumentTypeUpdateRequest : BaseRequest
{
    public DocumentType DocumentType { get; set; } = new DocumentType();
}