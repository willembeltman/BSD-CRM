namespace BSD.Business.Converters;

public static class TechnologyConverter
{
    public static BSD.Shared.Dtos.Technology ToDto(this BSD.Data.Entities.Technology item)
    {
        var newItem = new BSD.Shared.Dtos.Technology();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Technology ToEntity(this BSD.Shared.Dtos.Technology item)
    {
        var newItem = new BSD.Data.Entities.Technology();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Technology source, BSD.Data.Entities.Technology dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.IsProgrammeerTaal != source.IsProgrammeerTaal) { dest.IsProgrammeerTaal = source.IsProgrammeerTaal; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Technology source, BSD.Shared.Dtos.Technology dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.IsProgrammeerTaal != source.IsProgrammeerTaal) { dest.IsProgrammeerTaal = source.IsProgrammeerTaal; dirty = true; }
        return dirty;
    }
}