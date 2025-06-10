namespace BSD.Shared.RequestDtos;

public class ClientBearerReadRequest : BaseRequest
{
    public string ClientBearerId { get; set; }
}