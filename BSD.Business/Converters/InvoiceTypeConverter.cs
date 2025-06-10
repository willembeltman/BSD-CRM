namespace BSD.Business.Converters;

public static class InvoiceTypeConverter
{
    public static BSD.Shared.Dtos.InvoiceType ToDto(this BSD.Data.Entities.InvoiceType item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceType ToEntity(this BSD.Shared.Dtos.InvoiceType item)
    {
        var newItem = new BSD.Data.Entities.InvoiceType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceType source, BSD.Data.Entities.InvoiceType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceType source, BSD.Shared.Dtos.InvoiceType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
}