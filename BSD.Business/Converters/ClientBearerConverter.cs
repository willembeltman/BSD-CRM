namespace BSD.Business.Converters;

public static class ClientBearerConverter
{
    public static BSD.Shared.Dtos.ClientBearer ToDto(this BSD.Data.Entities.ClientBearer item)
    {
        var newItem = new BSD.Shared.Dtos.ClientBearer();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ClientBearer ToEntity(this BSD.Shared.Dtos.ClientBearer item)
    {
        var newItem = new BSD.Data.Entities.ClientBearer();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ClientBearer source, BSD.Data.Entities.ClientBearer dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ClientDeviceId != source.ClientDeviceId) { dest.ClientDeviceId = source.ClientDeviceId; dirty = true; }
        if (dest.ClientIpAddressId != source.ClientIpAddressId) { dest.ClientIpAddressId = source.ClientIpAddressId; dirty = true; }
        if (dest.UserId != source.UserId) { dest.UserId = source.UserId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ClientBearer source, BSD.Shared.Dtos.ClientBearer dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ClientDeviceId != source.ClientDeviceId) { dest.ClientDeviceId = source.ClientDeviceId; dirty = true; }
        if (dest.ClientIpAddressId != source.ClientIpAddressId) { dest.ClientIpAddressId = source.ClientIpAddressId; dirty = true; }
        if (dest.UserId != source.UserId) { dest.UserId = source.UserId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        return dirty;
    }
}