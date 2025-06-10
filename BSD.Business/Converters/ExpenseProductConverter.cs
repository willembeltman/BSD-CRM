namespace BSD.Business.Converters;

public static class ExpenseProductConverter
{
    public static BSD.Shared.Dtos.ExpenseProduct ToDto(this BSD.Data.Entities.ExpenseProduct item)
    {
        var newItem = new BSD.Shared.Dtos.ExpenseProduct();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExpenseProduct ToEntity(this BSD.Shared.Dtos.ExpenseProduct item)
    {
        var newItem = new BSD.Data.Entities.ExpenseProduct();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExpenseProduct source, BSD.Data.Entities.ExpenseProduct dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExpenseProduct source, BSD.Shared.Dtos.ExpenseProduct dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        return dirty;
    }
}