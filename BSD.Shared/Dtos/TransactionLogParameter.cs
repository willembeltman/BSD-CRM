using System;


namespace BSD.Shared.Dtos;

public class TransactionLogParameter
{
    public long Id { get; set; }
    public long TransactionLogId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}