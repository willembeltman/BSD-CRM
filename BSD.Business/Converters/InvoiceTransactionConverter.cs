namespace BSD.Business.Converters;

public static class InvoiceTransactionConverter
{
    public static BSD.Shared.Dtos.InvoiceTransaction ToDto(this BSD.Data.Entities.InvoiceTransaction item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceTransaction();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceTransaction ToEntity(this BSD.Shared.Dtos.InvoiceTransaction item)
    {
        var newItem = new BSD.Data.Entities.InvoiceTransaction();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceTransaction source, BSD.Data.Entities.InvoiceTransaction dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceTransaction source, BSD.Shared.Dtos.InvoiceTransaction dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.TransactionId != source.TransactionId) { dest.TransactionId = source.TransactionId; dirty = true; }
        return dirty;
    }
}