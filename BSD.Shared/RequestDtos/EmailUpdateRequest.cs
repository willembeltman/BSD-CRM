using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class EmailUpdateRequest : BaseRequest
{
    public Email Email { get; set; } = new Email();
}