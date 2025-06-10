namespace BSD.Business.Converters;

public static class TransactionLogParameterConverter
{
    public static BSD.Shared.Dtos.TransactionLogParameter ToDto(this BSD.Data.Entities.TransactionLogParameter item)
    {
        var newItem = new BSD.Shared.Dtos.TransactionLogParameter();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TransactionLogParameter ToEntity(this BSD.Shared.Dtos.TransactionLogParameter item)
    {
        var newItem = new BSD.Data.Entities.TransactionLogParameter();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TransactionLogParameter source, BSD.Data.Entities.TransactionLogParameter dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionLogId != source.TransactionLogId) { dest.TransactionLogId = source.TransactionLogId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TransactionLogParameter source, BSD.Shared.Dtos.TransactionLogParameter dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionLogId != source.TransactionLogId) { dest.TransactionLogId = source.TransactionLogId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
}