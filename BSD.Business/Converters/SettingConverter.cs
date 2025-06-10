namespace BSD.Business.Converters;

public static class SettingConverter
{
    public static BSD.Shared.Dtos.Setting ToDto(this BSD.Data.Entities.Setting item)
    {
        var newItem = new BSD.Shared.Dtos.Setting();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Setting ToEntity(this BSD.Shared.Dtos.Setting item)
    {
        var newItem = new BSD.Data.Entities.Setting();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Setting source, BSD.Data.Entities.Setting dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.ValueString != source.ValueString) { dest.ValueString = source.ValueString; dirty = true; }
        if (dest.ValueDouble != source.ValueDouble) { dest.ValueDouble = source.ValueDouble; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Setting source, BSD.Shared.Dtos.Setting dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.ValueString != source.ValueString) { dest.ValueString = source.ValueString; dirty = true; }
        if (dest.ValueDouble != source.ValueDouble) { dest.ValueDouble = source.ValueDouble; dirty = true; }
        return dirty;
    }
}