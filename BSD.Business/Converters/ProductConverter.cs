namespace BSD.Business.Converters;

public static class ProductConverter
{
    public static BSD.Shared.Dtos.Product ToDto(this BSD.Data.Entities.Product item)
    {
        var newItem = new BSD.Shared.Dtos.Product();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Product ToEntity(this BSD.Shared.Dtos.Product item)
    {
        var newItem = new BSD.Data.Entities.Product();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Product source, BSD.Data.Entities.Product dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Product source, BSD.Shared.Dtos.Product dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
}