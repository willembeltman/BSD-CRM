using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class DocumentCreateRequest : BaseRequest
{
    public Document Document { get; set; } = new Document();
}