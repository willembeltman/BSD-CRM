namespace BSD.Shared.RequestDtos;

public class UserDeleteRequest : BaseRequest
{
    public string UserId { get; set; } = string.Empty;
}