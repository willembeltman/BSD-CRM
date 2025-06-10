namespace BSD.Business.Converters;

public static class ProjectConverter
{
    public static BSD.Shared.Dtos.Project ToDto(this BSD.Data.Entities.Project item)
    {
        var newItem = new BSD.Shared.Dtos.Project();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Project ToEntity(this BSD.Shared.Dtos.Project item)
    {
        var newItem = new BSD.Data.Entities.Project();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Project source, BSD.Data.Entities.Project dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Publiekelijk != source.Publiekelijk) { dest.Publiekelijk = source.Publiekelijk; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Project source, BSD.Shared.Dtos.Project dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Publiekelijk != source.Publiekelijk) { dest.Publiekelijk = source.Publiekelijk; dirty = true; }
        return dirty;
    }
}