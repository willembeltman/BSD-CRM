namespace BSD.Business.Converters;

public static class WorkorderConverter
{
    public static BSD.Shared.Dtos.Workorder ToDto(this BSD.Data.Entities.Workorder item)
    {
        var newItem = new BSD.Shared.Dtos.Workorder();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Workorder ToEntity(this BSD.Shared.Dtos.Workorder item)
    {
        var newItem = new BSD.Data.Entities.Workorder();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Workorder source, BSD.Data.Entities.Workorder dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.RateId != source.RateId) { dest.RateId = source.RateId; dirty = true; }
        if (dest.Start != source.Start) { dest.Start = source.Start; dirty = true; }
        if (dest.Stop != source.Stop) { dest.Stop = source.Stop; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Workorder source, BSD.Shared.Dtos.Workorder dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.ProjectName != source.Project?.Name?.ToString()) { dest.ProjectName = source.Project?.Name?.ToString(); dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.RateId != source.RateId) { dest.RateId = source.RateId; dirty = true; }
        if (dest.RateName != source.Rate?.Name?.ToString()) { dest.RateName = source.Rate?.Name?.ToString(); dirty = true; }
        if (dest.Start != source.Start) { dest.Start = source.Start; dirty = true; }
        if (dest.Stop != source.Stop) { dest.Stop = source.Stop; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
}