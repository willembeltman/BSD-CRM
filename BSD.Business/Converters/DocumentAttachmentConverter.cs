namespace BSD.Business.Converters;

public static class DocumentAttachmentConverter
{
    public static BSD.Shared.Dtos.DocumentAttachment ToDto(this BSD.Data.Entities.DocumentAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.DocumentAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.DocumentAttachment ToEntity(this BSD.Shared.Dtos.DocumentAttachment item)
    {
        var newItem = new BSD.Data.Entities.DocumentAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.DocumentAttachment source, BSD.Data.Entities.DocumentAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.DocumentId != source.DocumentId) { dest.DocumentId = source.DocumentId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.DocumentAttachment source, BSD.Shared.Dtos.DocumentAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.DocumentId != source.DocumentId) { dest.DocumentId = source.DocumentId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        return dirty;
    }
}