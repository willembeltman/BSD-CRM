namespace BSD.Business.Converters;

public static class SupplierConverter
{
    public static BSD.Shared.Dtos.Supplier ToDto(this BSD.Data.Entities.Supplier item)
    {
        var newItem = new BSD.Shared.Dtos.Supplier();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Supplier ToEntity(this BSD.Shared.Dtos.Supplier item)
    {
        var newItem = new BSD.Data.Entities.Supplier();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Supplier source, BSD.Data.Entities.Supplier dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
        if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
        if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        if (dest.RekeningNumber != source.RekeningNumber) { dest.RekeningNumber = source.RekeningNumber; dirty = true; }
        if (dest.Publiekelijk != source.Publiekelijk) { dest.Publiekelijk = source.Publiekelijk; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Supplier source, BSD.Shared.Dtos.Supplier dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
        if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
        if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
        if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
        if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
        if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
        if (dest.RekeningNumber != source.RekeningNumber) { dest.RekeningNumber = source.RekeningNumber; dirty = true; }
        if (dest.Publiekelijk != source.Publiekelijk) { dest.Publiekelijk = source.Publiekelijk; dirty = true; }
        return dirty;
    }
}