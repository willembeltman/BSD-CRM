namespace BSD.Business.Converters;

public static class TransactionParameterConverter
{
    public static BSD.Shared.Dtos.TransactionParameter ToDto(this BSD.Data.Entities.TransactionParameter item)
    {
        var newItem = new BSD.Shared.Dtos.TransactionParameter();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TransactionParameter ToEntity(this BSD.Shared.Dtos.TransactionParameter item)
    {
        var newItem = new BSD.Data.Entities.TransactionParameter();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TransactionParameter source, BSD.Data.Entities.TransactionParameter dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TransactionParameter source, BSD.Shared.Dtos.TransactionParameter dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
}