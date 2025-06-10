namespace BSD.Business.Converters;

public static class InvoiceConverter
{
    public static BSD.Shared.Dtos.Invoice ToDto(this BSD.Data.Entities.Invoice item)
    {
        var newItem = new BSD.Shared.Dtos.Invoice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.Invoice ToEntity(this BSD.Shared.Dtos.Invoice item)
    {
        var newItem = new BSD.Data.Entities.Invoice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.Invoice source, BSD.Data.Entities.Invoice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.InvoiceTypeId != source.InvoiceTypeId) { dest.InvoiceTypeId = source.InvoiceTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.IsPayedInCash_By_CompanyUserId != source.IsPayedInCash_By_CompanyUserId) { dest.IsPayedInCash_By_CompanyUserId = source.IsPayedInCash_By_CompanyUserId; dirty = true; }
        if (dest.InvoiceNumber != source.InvoiceNumber) { dest.InvoiceNumber = source.InvoiceNumber; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.IsPayedInCash != source.IsPayedInCash) { dest.IsPayedInCash = source.IsPayedInCash; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.Invoice source, BSD.Shared.Dtos.Invoice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.InvoiceTypeId != source.InvoiceTypeId) { dest.InvoiceTypeId = source.InvoiceTypeId; dirty = true; }
        if (dest.ProjectId != source.ProjectId) { dest.ProjectId = source.ProjectId; dirty = true; }
        if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; dirty = true; }
        if (dest.IsPayedInCash_By_CompanyUserId != source.IsPayedInCash_By_CompanyUserId) { dest.IsPayedInCash_By_CompanyUserId = source.IsPayedInCash_By_CompanyUserId; dirty = true; }
        if (dest.InvoiceNumber != source.InvoiceNumber) { dest.InvoiceNumber = source.InvoiceNumber; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.IsPayedInCash != source.IsPayedInCash) { dest.IsPayedInCash = source.IsPayedInCash; dirty = true; }
        return dirty;
    }
}