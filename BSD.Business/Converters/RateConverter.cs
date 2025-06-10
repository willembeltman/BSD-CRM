namespace BSD.Business.Converters;

public static class RateConverter
{
    public static BSD.Shared.Dtos.Rate ToDto(this BSD.Data.Entities.Rate item)
    {
        var newItem = new BSD.Shared.Dtos.Rate();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Rate ToEntity(this BSD.Shared.Dtos.Rate item)
    {
        var newItem = new BSD.Data.Entities.Rate();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Rate source, BSD.Data.Entities.Rate dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Rate source, BSD.Shared.Dtos.Rate dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
}