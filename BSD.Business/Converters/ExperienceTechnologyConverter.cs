namespace BSD.Business.Converters;

public static class ExperienceTechnologyConverter
{
    public static BSD.Shared.Dtos.ExperienceTechnology ToDto(this BSD.Data.Entities.ExperienceTechnology item)
    {
        var newItem = new BSD.Shared.Dtos.ExperienceTechnology();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ExperienceTechnology ToEntity(this BSD.Shared.Dtos.ExperienceTechnology item)
    {
        var newItem = new BSD.Data.Entities.ExperienceTechnology();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ExperienceTechnology source, BSD.Data.Entities.ExperienceTechnology dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExperienceId != source.ExperienceId) { dest.ExperienceId = source.ExperienceId; dirty = true; }
        if (dest.TechnologyId != source.TechnologyId) { dest.TechnologyId = source.TechnologyId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ExperienceTechnology source, BSD.Shared.Dtos.ExperienceTechnology dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ExperienceId != source.ExperienceId) { dest.ExperienceId = source.ExperienceId; dirty = true; }
        if (dest.TechnologyId != source.TechnologyId) { dest.TechnologyId = source.TechnologyId; dirty = true; }
        return dirty;
    }
}