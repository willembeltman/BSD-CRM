namespace BSD.Business.Converters;

public static class CompanyUserConverter
{
    public static BSD.Shared.Dtos.CompanyUser ToDto(this BSD.Data.Entities.CompanyUser item)
    {
        var newItem = new BSD.Shared.Dtos.CompanyUser();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.CompanyUser ToEntity(this BSD.Shared.Dtos.CompanyUser item)
    {
        var newItem = new BSD.Data.Entities.CompanyUser();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.CompanyUser source, BSD.Data.Entities.CompanyUser dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.UserId != source.UserId) { dest.UserId = source.UserId; dirty = true; }
        if (dest.Eigenaar != source.Eigenaar) { dest.Eigenaar = source.Eigenaar; dirty = true; }
        if (dest.Admin != source.Admin) { dest.Admin = source.Admin; dirty = true; }
        if (dest.Actief != source.Actief) { dest.Actief = source.Actief; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.CompanyUser source, BSD.Shared.Dtos.CompanyUser dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.UserId != source.UserId) { dest.UserId = source.UserId; dirty = true; }
        if (dest.Eigenaar != source.Eigenaar) { dest.Eigenaar = source.Eigenaar; dirty = true; }
        if (dest.Admin != source.Admin) { dest.Admin = source.Admin; dirty = true; }
        if (dest.Actief != source.Actief) { dest.Actief = source.Actief; dirty = true; }
        return dirty;
    }
}