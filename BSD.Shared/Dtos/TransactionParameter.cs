namespace BSD.Shared.Dtos;

public class TransactionParameter
{
    public long Id { get; set; }
    public long TransactionId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}