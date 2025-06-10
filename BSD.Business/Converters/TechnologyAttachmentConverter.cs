using Storage.Proxy;

namespace BSD.Business.Converters;

public static class TechnologyAttachmentConverter
{
    public static BSD.Shared.Dtos.TechnologyAttachment ToDto(this BSD.Data.Entities.TechnologyAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.TechnologyAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.TechnologyAttachment ToEntity(this BSD.Shared.Dtos.TechnologyAttachment item)
    {
        var newItem = new BSD.Data.Entities.TechnologyAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.TechnologyAttachment source, BSD.Data.Entities.TechnologyAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TechnologyId != source.TechnologyId) { dest.TechnologyId = source.TechnologyId; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.TechnologyAttachment source, BSD.Shared.Dtos.TechnologyAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.TechnologyId != source.TechnologyId) { dest.TechnologyId = source.TechnologyId; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        if (dest.StorageFolder != source.StorageFolder) { dest.StorageFolder = source.StorageFolder; dirty = true; }
        dest.StorageFileUrl = source.GetUrl().Result;
        return dirty;
    }
}