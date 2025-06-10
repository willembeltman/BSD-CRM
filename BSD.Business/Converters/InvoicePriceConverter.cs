namespace BSD.Business.Converters;

public static class InvoicePriceConverter
{
    public static BSD.Shared.Dtos.InvoicePrice ToDto(this BSD.Data.Entities.InvoicePrice item)
    {
        var newItem = new BSD.Shared.Dtos.InvoicePrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoicePrice ToEntity(this BSD.Shared.Dtos.InvoicePrice item)
    {
        var newItem = new BSD.Data.Entities.InvoicePrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoicePrice source, BSD.Data.Entities.InvoicePrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoicePrice source, BSD.Shared.Dtos.InvoicePrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.InvoiceName != source.Invoice?.InvoiceNumber?.ToString()) { dest.InvoiceName = source.Invoice?.InvoiceNumber?.ToString(); dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.TaxRateName != source.TaxRate?.Name?.ToString()) { dest.TaxRateName = source.TaxRate?.Name?.ToString(); dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
}