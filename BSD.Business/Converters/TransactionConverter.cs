namespace BSD.Business.Converters;

public static class TransactionConverter
{
    public static BSD.Shared.Dtos.Transaction ToDto(this BSD.Data.Entities.Transaction item)
    {
        var newItem = new BSD.Shared.Dtos.Transaction();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Transaction ToEntity(this BSD.Shared.Dtos.Transaction item)
    {
        var newItem = new BSD.Data.Entities.Transaction();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Transaction source, BSD.Data.Entities.Transaction dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.ExternalTransactionId != source.ExternalTransactionId) { dest.ExternalTransactionId = source.ExternalTransactionId; dirty = true; }
        if (dest.IsPayed != source.IsPayed) { dest.IsPayed = source.IsPayed; dirty = true; }
        if (dest.DatePayed != source.DatePayed) { dest.DatePayed = source.DatePayed; dirty = true; }
        if (dest.DateCancelled != source.DateCancelled) { dest.DateCancelled = source.DateCancelled; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Transaction source, BSD.Shared.Dtos.Transaction dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.ExternalTransactionId != source.ExternalTransactionId) { dest.ExternalTransactionId = source.ExternalTransactionId; dirty = true; }
        if (dest.IsPayed != source.IsPayed) { dest.IsPayed = source.IsPayed; dirty = true; }
        if (dest.DatePayed != source.DatePayed) { dest.DatePayed = source.DatePayed; dirty = true; }
        if (dest.DateCancelled != source.DateCancelled) { dest.DateCancelled = source.DateCancelled; dirty = true; }
        return dirty;
    }
}