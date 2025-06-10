using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class DocumentTypeCreateRequest : BaseRequest
{
    public DocumentType DocumentType { get; set; } = new DocumentType();
}