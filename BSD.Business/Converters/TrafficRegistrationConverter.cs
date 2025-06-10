namespace BSD.Business.Converters;

public static class TrafficRegistrationConverter
{
    public static BSD.Shared.Dtos.TrafficRegistration ToDto(this BSD.Data.Entities.TrafficRegistration item)
    {
        var newItem = new BSD.Shared.Dtos.TrafficRegistration();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TrafficRegistration ToEntity(this BSD.Shared.Dtos.TrafficRegistration item)
    {
        var newItem = new BSD.Data.Entities.TrafficRegistration();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TrafficRegistration source, BSD.Data.Entities.TrafficRegistration dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.KilometerStart != source.KilometerStart) { dest.KilometerStart = source.KilometerStart; dirty = true; }
        if (dest.KilometerStop != source.KilometerStop) { dest.KilometerStop = source.KilometerStop; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TrafficRegistration source, BSD.Shared.Dtos.TrafficRegistration dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.KilometerStart != source.KilometerStart) { dest.KilometerStart = source.KilometerStart; dirty = true; }
        if (dest.KilometerStop != source.KilometerStop) { dest.KilometerStop = source.KilometerStop; dirty = true; }
        if (dest.AmountKm != source.AmountKm) { dest.AmountKm = source.AmountKm; dirty = true; }
        return dirty;
    }
}