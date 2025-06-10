namespace BSD.Business.Converters;

public static class ExpensePriceConverter
{
    public static BSD.Shared.Dtos.ExpensePrice ToDto(this BSD.Data.Entities.ExpensePrice item)
    {
        var newItem = new BSD.Shared.Dtos.ExpensePrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExpensePrice ToEntity(this BSD.Shared.Dtos.ExpensePrice item)
    {
        var newItem = new BSD.Data.Entities.ExpensePrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExpensePrice source, BSD.Data.Entities.ExpensePrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExpensePrice source, BSD.Shared.Dtos.ExpensePrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
}