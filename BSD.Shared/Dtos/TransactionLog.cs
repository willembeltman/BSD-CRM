using System;

namespace BSD.Shared.Dtos;

public class TransactionLog
{
    public long Id { get; set; }
    public long? TransactionId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}