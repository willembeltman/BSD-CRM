namespace BSD.Business.Converters;

public static class InvoiceRowConverter
{
    public static BSD.Shared.Dtos.InvoiceRow ToDto(this BSD.Data.Entities.InvoiceRow item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceRow();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceRow ToEntity(this BSD.Shared.Dtos.InvoiceRow item)
    {
        var newItem = new BSD.Data.Entities.InvoiceRow();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceRow source, BSD.Data.Entities.InvoiceRow dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.PricePerPiece != source.PricePerPiece) { dest.PricePerPiece = source.PricePerPiece; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.IsDiscountRow != source.IsDiscountRow) { dest.IsDiscountRow = source.IsDiscountRow; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceRow source, BSD.Shared.Dtos.InvoiceRow dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.InvoiceName != source.Invoice?.InvoiceNumber?.ToString()) { dest.InvoiceName = source.Invoice?.InvoiceNumber?.ToString(); dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.TaxRateName != source.TaxRate?.Name?.ToString()) { dest.TaxRateName = source.TaxRate?.Name?.ToString(); dirty = true; }
        if (dest.Amount != source.Amount) { dest.Amount = source.Amount; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.PricePerPiece != source.PricePerPiece) { dest.PricePerPiece = source.PricePerPiece; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.IsDiscountRow != source.IsDiscountRow) { dest.IsDiscountRow = source.IsDiscountRow; dirty = true; }
        return dirty;
    }
}