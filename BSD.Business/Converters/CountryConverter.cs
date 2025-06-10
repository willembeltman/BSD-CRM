namespace BSD.Business.Converters;

public static class CountryConverter
{
    public static BSD.Shared.Dtos.Country ToDto(this BSD.Data.Entities.Country item)
    {
        var newItem = new BSD.Shared.Dtos.Country();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Country ToEntity(this BSD.Shared.Dtos.Country item)
    {
        var newItem = new BSD.Data.Entities.Country();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Country source, BSD.Data.Entities.Country dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Code != source.Code) { dest.Code = source.Code; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Country source, BSD.Shared.Dtos.Country dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Code != source.Code) { dest.Code = source.Code; dirty = true; }
        return dirty;
    }
}