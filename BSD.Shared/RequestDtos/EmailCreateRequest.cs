using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class EmailCreateRequest : BaseRequest
{
    public Email Email { get; set; } = new Email();
}