namespace BSD.Business.Converters;

public static class ExpenseTypeConverter
{
    public static BSD.Shared.Dtos.ExpenseType ToDto(this BSD.Data.Entities.ExpenseType item)
    {
        var newItem = new BSD.Shared.Dtos.ExpenseType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExpenseType ToEntity(this BSD.Shared.Dtos.ExpenseType item)
    {
        var newItem = new BSD.Data.Entities.ExpenseType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExpenseType source, BSD.Data.Entities.ExpenseType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.IsVolledigeKosten != source.IsVolledigeKosten) { dest.IsVolledigeKosten = source.IsVolledigeKosten; dirty = true; }
        if (dest.IsRepresentatieKosten != source.IsRepresentatieKosten) { dest.IsRepresentatieKosten = source.IsRepresentatieKosten; dirty = true; }
        if (dest.IsHalfTellen != source.IsHalfTellen) { dest.IsHalfTellen = source.IsHalfTellen; dirty = true; }
        if (dest.BedrijfsKostenType != source.BedrijfsKostenType) { dest.BedrijfsKostenType = source.BedrijfsKostenType; dirty = true; }
        if (dest.AfschrijfKostenType != source.AfschrijfKostenType) { dest.AfschrijfKostenType = source.AfschrijfKostenType; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExpenseType source, BSD.Shared.Dtos.ExpenseType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.IsVolledigeKosten != source.IsVolledigeKosten) { dest.IsVolledigeKosten = source.IsVolledigeKosten; dirty = true; }
        if (dest.IsRepresentatieKosten != source.IsRepresentatieKosten) { dest.IsRepresentatieKosten = source.IsRepresentatieKosten; dirty = true; }
        if (dest.IsHalfTellen != source.IsHalfTellen) { dest.IsHalfTellen = source.IsHalfTellen; dirty = true; }
        if (dest.BedrijfsKostenType != source.BedrijfsKostenType) { dest.BedrijfsKostenType = source.BedrijfsKostenType; dirty = true; }
        if (dest.AfschrijfKostenType != source.AfschrijfKostenType) { dest.AfschrijfKostenType = source.AfschrijfKostenType; dirty = true; }
        return dirty;
    }
}