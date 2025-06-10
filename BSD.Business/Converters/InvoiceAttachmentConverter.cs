namespace BSD.Business.Converters;

public static class InvoiceAttachmentConverter
{
    public static BSD.Shared.Dtos.InvoiceAttachment ToDto(this BSD.Data.Entities.InvoiceAttachment item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceAttachment ToEntity(this BSD.Shared.Dtos.InvoiceAttachment item)
    {
        var newItem = new BSD.Data.Entities.InvoiceAttachment();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceAttachment source, BSD.Data.Entities.InvoiceAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.IsInvoicePDF != source.IsInvoicePDF) { dest.IsInvoicePDF = source.IsInvoicePDF; dirty = true; }
        if (dest.IsWorkorderPDF != source.IsWorkorderPDF) { dest.IsWorkorderPDF = source.IsWorkorderPDF; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceAttachment source, BSD.Shared.Dtos.InvoiceAttachment dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.IsInvoicePDF != source.IsInvoicePDF) { dest.IsInvoicePDF = source.IsInvoicePDF; dirty = true; }
        if (dest.IsWorkorderPDF != source.IsWorkorderPDF) { dest.IsWorkorderPDF = source.IsWorkorderPDF; dirty = true; }
        if (dest.StorageFileName != source.StorageFileName) { dest.StorageFileName = source.StorageFileName; dirty = true; }
        if (dest.StorageLength != source.StorageLength) { dest.StorageLength = source.StorageLength; dirty = true; }
        if (dest.StorageMimeType != source.StorageMimeType) { dest.StorageMimeType = source.StorageMimeType; dirty = true; }
        if (dest.StorageFolder != source.StorageFolder) { dest.StorageFolder = source.StorageFolder; dirty = true; }
        return dirty;
    }
}