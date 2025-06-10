namespace BSD.Business.Converters;

public static class DocumentConverter
{
    public static BSD.Shared.Dtos.Document ToDto(this BSD.Data.Entities.Document item)
    {
        var newItem = new BSD.Shared.Dtos.Document();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Document ToEntity(this BSD.Shared.Dtos.Document item)
    {
        var newItem = new BSD.Data.Entities.Document();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Document source, BSD.Data.Entities.Document dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.DocumentTypeId != source.DocumentTypeId) { dest.DocumentTypeId = source.DocumentTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Document source, BSD.Shared.Dtos.Document dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.DocumentTypeId != source.DocumentTypeId) { dest.DocumentTypeId = source.DocumentTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.SupplierId != source.SupplierId) { dest.SupplierId = source.SupplierId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        return dirty;
    }
}