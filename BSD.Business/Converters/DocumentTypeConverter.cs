namespace BSD.Business.Converters;

public static class DocumentTypeConverter
{
    public static BSD.Shared.Dtos.DocumentType ToDto(this BSD.Data.Entities.DocumentType item)
    {
        var newItem = new BSD.Shared.Dtos.DocumentType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.DocumentType ToEntity(this BSD.Shared.Dtos.DocumentType item)
    {
        var newItem = new BSD.Data.Entities.DocumentType();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.DocumentType source, BSD.Data.Entities.DocumentType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.DocumentType source, BSD.Shared.Dtos.DocumentType dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
}