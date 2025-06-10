namespace BSD.Business.Converters;

public static class ExperienceConverter
{
    public static BSD.Shared.Dtos.Experience ToDto(this BSD.Data.Entities.Experience item)
    {
        var newItem = new BSD.Shared.Dtos.Experience();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Experience ToEntity(this BSD.Shared.Dtos.Experience item)
    {
        var newItem = new BSD.Data.Entities.Experience();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Experience source, BSD.Data.Entities.Experience dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Start != source.Start) { dest.Start = source.Start; dirty = true; }
        if (dest.Stop != source.Stop) { dest.Stop = source.Stop; dirty = true; }
        if (dest.AmountUur != source.AmountUur) { dest.AmountUur = source.AmountUur; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Experience source, BSD.Shared.Dtos.Experience dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Start != source.Start) { dest.Start = source.Start; dirty = true; }
        if (dest.Stop != source.Stop) { dest.Stop = source.Stop; dirty = true; }
        if (dest.AmountUur != source.AmountUur) { dest.AmountUur = source.AmountUur; dirty = true; }
        return dirty;
    }
}