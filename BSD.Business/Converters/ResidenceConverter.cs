namespace BSD.Business.Converters;

public static class ResidenceConverter
{
    public static BSD.Shared.Dtos.Residence ToDto(this BSD.Data.Entities.Residence item)
    {
        var newItem = new BSD.Shared.Dtos.Residence();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Residence ToEntity(this BSD.Shared.Dtos.Residence item)
    {
        var newItem = new BSD.Data.Entities.Residence();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Residence source, BSD.Data.Entities.Residence dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.StartDate != source.StartDate) { dest.StartDate = source.StartDate; dirty = true; }
        if (dest.EndDate != source.EndDate) { dest.EndDate = source.EndDate; dirty = true; }
        if (dest.WOZWaarde != source.WOZWaarde) { dest.WOZWaarde = source.WOZWaarde; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Residence source, BSD.Shared.Dtos.Residence dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.StartDate != source.StartDate) { dest.StartDate = source.StartDate; dirty = true; }
        if (dest.EndDate != source.EndDate) { dest.EndDate = source.EndDate; dirty = true; }
        if (dest.WOZWaarde != source.WOZWaarde) { dest.WOZWaarde = source.WOZWaarde; dirty = true; }
        return dirty;
    }
}