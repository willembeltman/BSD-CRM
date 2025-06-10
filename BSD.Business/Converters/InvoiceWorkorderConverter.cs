namespace BSD.Business.Converters;

public static class InvoiceWorkorderConverter
{
    public static BSD.Shared.Dtos.InvoiceWorkorder ToDto(this BSD.Data.Entities.InvoiceWorkorder item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceWorkorder();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceWorkorder ToEntity(this BSD.Shared.Dtos.InvoiceWorkorder item)
    {
        var newItem = new BSD.Data.Entities.InvoiceWorkorder();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceWorkorder source, BSD.Data.Entities.InvoiceWorkorder dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.WorkorderId != source.WorkorderId) { dest.WorkorderId = source.WorkorderId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceWorkorder source, BSD.Shared.Dtos.InvoiceWorkorder dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.InvoiceName != source.Invoice?.InvoiceNumber?.ToString()) { dest.InvoiceName = source.Invoice?.InvoiceNumber?.ToString(); dirty = true; }
        if (dest.WorkorderId != source.WorkorderId) { dest.WorkorderId = source.WorkorderId; dirty = true; }
        if (dest.WorkorderName != source.Workorder?.Name?.ToString()) { dest.WorkorderName = source.Workorder?.Name?.ToString(); dirty = true; }
        return dirty;
    }
}