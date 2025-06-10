namespace BSD.Business.Converters;

public static class ClientIpAddressConverter
{
    public static BSD.Shared.Dtos.ClientIpAddress ToDto(this BSD.Data.Entities.ClientIpAddress item)
    {
        var newItem = new BSD.Shared.Dtos.ClientIpAddress();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ClientIpAddress ToEntity(this BSD.Shared.Dtos.ClientIpAddress item)
    {
        var newItem = new BSD.Data.Entities.ClientIpAddress();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ClientIpAddress source, BSD.Data.Entities.ClientIpAddress dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.IpAddress != source.IpAddress) { dest.IpAddress = source.IpAddress; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ClientIpAddress source, BSD.Shared.Dtos.ClientIpAddress dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.IpAddress != source.IpAddress) { dest.IpAddress = source.IpAddress; dirty = true; }
        return dirty;
    }
}