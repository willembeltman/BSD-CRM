namespace BSD.Business.Converters;

public static class TaxRateConverter
{
    public static BSD.Shared.Dtos.TaxRate ToDto(this BSD.Data.Entities.TaxRate item)
    {
        var newItem = new BSD.Shared.Dtos.TaxRate();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TaxRate ToEntity(this BSD.Shared.Dtos.TaxRate item)
    {
        var newItem = new BSD.Data.Entities.TaxRate();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TaxRate source, BSD.Data.Entities.TaxRate dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Percentage != source.Percentage) { dest.Percentage = source.Percentage; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TaxRate source, BSD.Shared.Dtos.TaxRate dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.CountryName != source.Country?.Name?.ToString()) { dest.CountryName = source.Country?.Name?.ToString(); dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Percentage != source.Percentage) { dest.Percentage = source.Percentage; dirty = true; }
        return dirty;
    }
}