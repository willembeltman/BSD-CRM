namespace BSD.Business.Converters;

public static class CompanyConverter
{
    public static BSD.Shared.Dtos.Company ToDto(this BSD.Data.Entities.Company item)
    {
        var newItem = new BSD.Shared.Dtos.Company();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Company ToEntity(this BSD.Shared.Dtos.Company item)
    {
        var newItem = new BSD.Data.Entities.Company();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Company source, BSD.Data.Entities.Company dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
        if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
        if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
        if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        if (dest.Website != source.Website) { dest.Website = source.Website; dirty = true; }
        if (dest.BtwNumber != source.BtwNumber) { dest.BtwNumber = source.BtwNumber; dirty = true; }
        if (dest.KvkNumber != source.KvkNumber) { dest.KvkNumber = source.KvkNumber; dirty = true; }
        if (dest.Iban != source.Iban) { dest.Iban = source.Iban; dirty = true; }
        if (dest.PayNL_ApiToken != source.PayNL_ApiToken) { dest.PayNL_ApiToken = source.PayNL_ApiToken; dirty = true; }
        if (dest.PayNL_ServiceId != source.PayNL_ServiceId) { dest.PayNL_ServiceId = source.PayNL_ServiceId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Company source, BSD.Shared.Dtos.Company dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
        if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
        if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
        if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        if (dest.Website != source.Website) { dest.Website = source.Website; dirty = true; }
        if (dest.BtwNumber != source.BtwNumber) { dest.BtwNumber = source.BtwNumber; dirty = true; }
        if (dest.KvkNumber != source.KvkNumber) { dest.KvkNumber = source.KvkNumber; dirty = true; }
        if (dest.Iban != source.Iban) { dest.Iban = source.Iban; dirty = true; }
        if (dest.PayNL_ApiToken != source.PayNL_ApiToken) { dest.PayNL_ApiToken = source.PayNL_ApiToken; dirty = true; }
        if (dest.PayNL_ServiceId != source.PayNL_ServiceId) { dest.PayNL_ServiceId = source.PayNL_ServiceId; dirty = true; }
        return dirty;
    }
}