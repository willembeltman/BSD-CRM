namespace BSD.Business.Converters;

public static class ClientDeviceConverter
{
    public static BSD.Shared.Dtos.ClientDevice ToDto(this BSD.Data.Entities.ClientDevice item)
    {
        var newItem = new BSD.Shared.Dtos.ClientDevice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ClientDevice ToEntity(this BSD.Shared.Dtos.ClientDevice item)
    {
        var newItem = new BSD.Data.Entities.ClientDevice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ClientDevice source, BSD.Data.Entities.ClientDevice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.DeviceHash != source.DeviceHash) { dest.DeviceHash = source.DeviceHash; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ClientDevice source, BSD.Shared.Dtos.ClientDevice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.DeviceHash != source.DeviceHash) { dest.DeviceHash = source.DeviceHash; dirty = true; }
        return dirty;
    }
}