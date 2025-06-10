using System;


namespace BSD.Shared.Dtos;

public class BankStatementExpense
{
    public long Id { get; set; }
    public long? BankStatementId { get; set; }
    public long? ExpenseId { get; set; }
}