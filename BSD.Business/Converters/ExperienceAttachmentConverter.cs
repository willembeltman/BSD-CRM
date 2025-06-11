using Storage.Proxy;

namespace BSD.Business.Converters;

public static class ExperienceAttachmentConverter
{
    public static BSD.Shared.Dtos.ExperienceAttachment ToDto(this BSD.Data.Entities.ExperienceAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.ExperienceAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExperienceAttachment ToEntity(this BSD.Shared.Dtos.ExperienceAttachment item)
    {
        var newItem = new BSD.Data.Entities.ExperienceAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExperienceAttachment source, BSD.Data.Entities.ExperienceAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExperienceId != source.ExperienceId) { dest.ExperienceId = source.ExperienceId; dirty = true; }
        if (dest.Spotlight != source.Spotlight) { dest.Spotlight = source.Spotlight; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExperienceAttachment source, BSD.Shared.Dtos.ExperienceAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExperienceId != source.ExperienceId) { dest.ExperienceId = source.ExperienceId; dirty = true; }
        if (dest.Spotlight != source.Spotlight) { dest.Spotlight = source.Spotlight; dirty = true; }
        dest.StorageFileUrl = source.GetUrl().Result;
        return dirty;
    }
}