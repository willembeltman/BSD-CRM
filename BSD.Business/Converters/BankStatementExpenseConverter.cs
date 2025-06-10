namespace BSD.Business.Converters;

public static class BankStatementExpenseConverter
{
    public static BSD.Shared.Dtos.BankStatementExpense ToDto(this BSD.Data.Entities.BankStatementExpense item)
    {
        var newItem = new BSD.Shared.Dtos.BankStatementExpense();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.BankStatementExpense ToEntity(this BSD.Shared.Dtos.BankStatementExpense item)
    {
        var newItem = new BSD.Data.Entities.BankStatementExpense();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.BankStatementExpense source, BSD.Data.Entities.BankStatementExpense dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.BankStatementId != source.BankStatementId) { dest.BankStatementId = source.BankStatementId; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.BankStatementExpense source, BSD.Shared.Dtos.BankStatementExpense dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.BankStatementId != source.BankStatementId) { dest.BankStatementId = source.BankStatementId; dirty = true; }
        if (dest.BankStatementName != source.BankStatement?.EigenRekeningNumber?.ToString()) { dest.BankStatementName = source.BankStatement?.EigenRekeningNumber?.ToString(); dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        return dirty;
    }
}