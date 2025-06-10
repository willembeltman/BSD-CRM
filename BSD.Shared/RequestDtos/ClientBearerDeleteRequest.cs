namespace BSD.Shared.RequestDtos;

public class ClientBearerDeleteRequest : BaseRequest
{
    public string ClientBearerId { get; set; }
}