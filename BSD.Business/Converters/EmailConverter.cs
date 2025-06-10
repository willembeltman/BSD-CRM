namespace BSD.Business.Converters;

public static class EmailConverter
{
    public static BSD.Shared.Dtos.Email ToDto(this BSD.Data.Entities.Email item)
    {
        var newItem = new BSD.Shared.Dtos.Email();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Email ToEntity(this BSD.Shared.Dtos.Email item)
    {
        var newItem = new BSD.Data.Entities.Email();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Email source, BSD.Data.Entities.Email dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.EmailDate != source.EmailDate) { dest.EmailDate = source.EmailDate; dirty = true; }
        if (dest.EmailFrom != source.EmailFrom) { dest.EmailFrom = source.EmailFrom; dirty = true; }
        if (dest.EmailTo != source.EmailTo) { dest.EmailTo = source.EmailTo; dirty = true; }
        if (dest.EmailIndex != source.EmailIndex) { dest.EmailIndex = source.EmailIndex; dirty = true; }
        if (dest.EmailSubject != source.EmailSubject) { dest.EmailSubject = source.EmailSubject; dirty = true; }
        if (dest.EmailHtmlBody != source.EmailHtmlBody) { dest.EmailHtmlBody = source.EmailHtmlBody; dirty = true; }
        if (dest.EmailTextBody != source.EmailTextBody) { dest.EmailTextBody = source.EmailTextBody; dirty = true; }
        if (dest.Hidden != source.Hidden) { dest.Hidden = source.Hidden; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Email source, BSD.Shared.Dtos.Email dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.EmailDate != source.EmailDate) { dest.EmailDate = source.EmailDate; dirty = true; }
        if (dest.EmailFrom != source.EmailFrom) { dest.EmailFrom = source.EmailFrom; dirty = true; }
        if (dest.EmailTo != source.EmailTo) { dest.EmailTo = source.EmailTo; dirty = true; }
        if (dest.EmailIndex != source.EmailIndex) { dest.EmailIndex = source.EmailIndex; dirty = true; }
        if (dest.EmailSubject != source.EmailSubject) { dest.EmailSubject = source.EmailSubject; dirty = true; }
        if (dest.EmailHtmlBody != source.EmailHtmlBody) { dest.EmailHtmlBody = source.EmailHtmlBody; dirty = true; }
        if (dest.EmailTextBody != source.EmailTextBody) { dest.EmailTextBody = source.EmailTextBody; dirty = true; }
        if (dest.Hidden != source.Hidden) { dest.Hidden = source.Hidden; dirty = true; }
        return dirty;
    }
}