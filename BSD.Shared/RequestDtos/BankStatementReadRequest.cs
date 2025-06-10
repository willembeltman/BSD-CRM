namespace BSD.Shared.RequestDtos;

public class BankStatementReadRequest : BaseRequest
{
    public long BankStatementId { get; set; }
}