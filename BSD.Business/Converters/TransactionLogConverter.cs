namespace BSD.Business.Converters;

public static class TransactionLogConverter
{
    public static BSD.Shared.Dtos.TransactionLog ToDto(this BSD.Data.Entities.TransactionLog item)
    {
        var newItem = new BSD.Shared.Dtos.TransactionLog();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TransactionLog ToEntity(this BSD.Shared.Dtos.TransactionLog item)
    {
        var newItem = new BSD.Data.Entities.TransactionLog();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TransactionLog source, BSD.Data.Entities.TransactionLog dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        if (dest.DateCreated != source.DateCreated) { dest.DateCreated = source.DateCreated; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TransactionLog source, BSD.Shared.Dtos.TransactionLog dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        if (dest.DateCreated != source.DateCreated) { dest.DateCreated = source.DateCreated; dirty = true; }
        return dirty;
    }
}