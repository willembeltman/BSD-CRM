using Storage.Proxy;

namespace BSD.Business.Converters;

public static class WorkorderAttachmentConverter
{
    public static BSD.Shared.Dtos.WorkorderAttachment ToDto(this BSD.Data.Entities.WorkorderAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.WorkorderAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.WorkorderAttachment ToEntity(this BSD.Shared.Dtos.WorkorderAttachment item)
    {
        var newItem = new BSD.Data.Entities.WorkorderAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.WorkorderAttachment source, BSD.Data.Entities.WorkorderAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.WorkorderId != source.WorkorderId) { dest.WorkorderId = source.WorkorderId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.WorkorderAttachment source, BSD.Shared.Dtos.WorkorderAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.WorkorderId != source.WorkorderId) { dest.WorkorderId = source.WorkorderId; dirty = true; }
        if (dest.WorkorderName != source.Workorder?.Name?.ToString()) { dest.WorkorderName = source.Workorder?.Name?.ToString(); dirty = true; }
        dest.StorageFileUrl = source.GetUrl().Result;
        return dirty;
    }
}