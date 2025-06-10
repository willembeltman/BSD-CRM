namespace BSD.Business.Converters;

public static class ExpenseAttachmentConverter
{
    public static BSD.Shared.Dtos.ExpenseAttachment ToDto(this BSD.Data.Entities.ExpenseAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.ExpenseAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExpenseAttachment ToEntity(this BSD.Shared.Dtos.ExpenseAttachment item)
    {
        var newItem = new BSD.Data.Entities.ExpenseAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExpenseAttachment source, BSD.Data.Entities.ExpenseAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.EmailUniqueId != source.EmailUniqueId) { dest.EmailUniqueId = source.EmailUniqueId; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExpenseAttachment source, BSD.Shared.Dtos.ExpenseAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExpenseId != source.ExpenseId) { dest.ExpenseId = source.ExpenseId; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.EmailUniqueId != source.EmailUniqueId) { dest.EmailUniqueId = source.EmailUniqueId; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        if (dest.StorageFolder != source.StorageFolder) { dest.StorageFolder = source.StorageFolder; dirty = true; }
        return dirty;
    }
}