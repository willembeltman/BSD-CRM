using System;


namespace BSD.Shared.Dtos;

public class ExpensePrice
{
    public long Id { get; set; }
    public long? ExpenseId { get; set; }
    public long? TaxRateId { get; set; }
    public double Price { get; set; }
}