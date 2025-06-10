namespace BSD.Business.Converters;

public static class InvoiceProductConverter
{
    public static BSD.Shared.Dtos.InvoiceProduct ToDto(this BSD.Data.Entities.InvoiceProduct item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceProduct();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceProduct ToEntity(this BSD.Shared.Dtos.InvoiceProduct item)
    {
        var newItem = new BSD.Data.Entities.InvoiceProduct();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceProduct source, BSD.Data.Entities.InvoiceProduct dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceProduct source, BSD.Shared.Dtos.InvoiceProduct dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        return dirty;
    }
}