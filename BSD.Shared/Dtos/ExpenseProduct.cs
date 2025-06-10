using System;


namespace BSD.Shared.Dtos;

public class ExpenseProduct
{
    public long Id { get; set; }
    public long? ExpenseId { get; set; }
    public long? ProductId { get; set; }
    public int Amount { get; set; }
}