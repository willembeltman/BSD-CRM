using System;


namespace BSD.Shared.Dtos;

public class Transaction
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public double Price { get; set; }
    public string? ExternalTransactionId { get; set; }
    public bool IsPayed { get; set; }
    public DateTime? DatePayed { get; set; }
    public DateTime? DateCancelled { get; set; }
}