namespace BSD.Business.Converters;

public static class ExpenseConverter
{
    public static BSD.Shared.Dtos.Expense ToDto(this BSD.Data.Entities.Expense item)
    {
        var newItem = new BSD.Shared.Dtos.Expense();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Expense ToEntity(this BSD.Shared.Dtos.Expense item)
    {
        var newItem = new BSD.Data.Entities.Expense();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Expense source, BSD.Data.Entities.Expense dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.ExpenseTypeId != source.ExpenseTypeId) { dest.ExpenseTypeId = source.ExpenseTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.DateKapot != source.DateKapot) { dest.DateKapot = source.DateKapot; dirty = true; }
        if (dest.IsPayedInCash != source.IsPayedInCash) { dest.IsPayedInCash = source.IsPayedInCash; dirty = true; }
        if (dest.Restwaarde != source.Restwaarde) { dest.Restwaarde = source.Restwaarde; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Expense source, BSD.Shared.Dtos.Expense dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.ExpenseTypeId != source.ExpenseTypeId) { dest.ExpenseTypeId = source.ExpenseTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.DateKapot != source.DateKapot) { dest.DateKapot = source.DateKapot; dirty = true; }
        if (dest.IsPayedInCash != source.IsPayedInCash) { dest.IsPayedInCash = source.IsPayedInCash; dirty = true; }
        if (dest.Restwaarde != source.Restwaarde) { dest.Restwaarde = source.Restwaarde; dirty = true; }
        return dirty;
    }
}