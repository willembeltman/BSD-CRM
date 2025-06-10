namespace BSD.Business.Converters;

public static class UserConverter
{
    public static BSD.Shared.Dtos.User ToDto(this BSD.Data.Entities.User item)
    {
        var newItem = new BSD.Shared.Dtos.User();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.User ToEntity(this BSD.Shared.Dtos.User item)
    {
        var newItem = new BSD.Data.Entities.User();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.User source, BSD.Data.Entities.User dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CurrentCompanyId != source.CurrentCompanyId) { dest.CurrentCompanyId = source.CurrentCompanyId; dirty = true; }
        if (dest.PasswordHash != source.PasswordHash) { dest.PasswordHash = source.PasswordHash; dirty = true; }
        if (dest.LockedOut != source.LockedOut) { dest.LockedOut = source.LockedOut; dirty = true; }
        if (dest.UserName != source.UserName) { dest.UserName = source.UserName; dirty = true; }
        if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.User source, BSD.Shared.Dtos.User dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CurrentCompanyId != source.CurrentCompanyId) { dest.CurrentCompanyId = source.CurrentCompanyId; dirty = true; }
        if (dest.PasswordHash != source.PasswordHash) { dest.PasswordHash = source.PasswordHash; dirty = true; }
        if (dest.LockedOut != source.LockedOut) { dest.LockedOut = source.LockedOut; dirty = true; }
        if (dest.UserName != source.UserName) { dest.UserName = source.UserName; dirty = true; }
        if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        return dirty;
    }
}