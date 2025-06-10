namespace BSD.Business.Converters;

public static class ClientDevicePropertyConverter
{
    public static BSD.Shared.Dtos.ClientDeviceProperty ToDto(this BSD.Data.Entities.ClientDeviceProperty item)
    {
        var newItem = new BSD.Shared.Dtos.ClientDeviceProperty();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ClientDeviceProperty ToEntity(this BSD.Shared.Dtos.ClientDeviceProperty item)
    {
        var newItem = new BSD.Data.Entities.ClientDeviceProperty();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ClientDeviceProperty source, BSD.Data.Entities.ClientDeviceProperty dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ClientDeviceId != source.ClientDeviceId) { dest.ClientDeviceId = source.ClientDeviceId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ClientDeviceProperty source, BSD.Shared.Dtos.ClientDeviceProperty dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ClientDeviceId != source.ClientDeviceId) { dest.ClientDeviceId = source.ClientDeviceId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Value != source.Value) { dest.Value = source.Value; dirty = true; }
        return dirty;
    }
}