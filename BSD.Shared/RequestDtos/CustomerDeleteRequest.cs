namespace BSD.Shared.RequestDtos;

public class CustomerDeleteRequest : BaseRequest
{
    public long CustomerId { get; set; }
}