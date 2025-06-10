namespace BSD.Business.Converters;

public static class InvoiceEmailConverter
{
    public static BSD.Shared.Dtos.InvoiceEmail ToDto(this BSD.Data.Entities.InvoiceEmail item)
    {
        var newItem = new BSD.Shared.Dtos.InvoiceEmail();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.InvoiceEmail ToEntity(this BSD.Shared.Dtos.InvoiceEmail item)
    {
        var newItem = new BSD.Data.Entities.InvoiceEmail();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.InvoiceEmail source, BSD.Data.Entities.InvoiceEmail dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.EmailFrom != source.EmailFrom) { dest.EmailFrom = source.EmailFrom; dirty = true; }
        if (dest.EmailTo != source.EmailTo) { dest.EmailTo = source.EmailTo; dirty = true; }
        if (dest.Title != source.Title) { dest.Title = source.Title; dirty = true; }
        if (dest.Body != source.Body) { dest.Body = source.Body; dirty = true; }
        if (dest.DateVerzonden != source.DateVerzonden) { dest.DateVerzonden = source.DateVerzonden; dirty = true; }
        if (dest.InvoiceGezien != source.InvoiceGezien) { dest.InvoiceGezien = source.InvoiceGezien; dirty = true; }
        if (dest.DateInvoiceGezien != source.DateInvoiceGezien) { dest.DateInvoiceGezien = source.DateInvoiceGezien; dirty = true; }
        if (dest.EmailGezien != source.EmailGezien) { dest.EmailGezien = source.EmailGezien; dirty = true; }
        if (dest.DateEmailGezien != source.DateEmailGezien) { dest.DateEmailGezien = source.DateEmailGezien; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.InvoiceEmail source, BSD.Shared.Dtos.InvoiceEmail dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        if (dest.EmailFrom != source.EmailFrom) { dest.EmailFrom = source.EmailFrom; dirty = true; }
        if (dest.EmailTo != source.EmailTo) { dest.EmailTo = source.EmailTo; dirty = true; }
        if (dest.Title != source.Title) { dest.Title = source.Title; dirty = true; }
        if (dest.Body != source.Body) { dest.Body = source.Body; dirty = true; }
        if (dest.DateVerzonden != source.DateVerzonden) { dest.DateVerzonden = source.DateVerzonden; dirty = true; }
        if (dest.InvoiceGezien != source.InvoiceGezien) { dest.InvoiceGezien = source.InvoiceGezien; dirty = true; }
        if (dest.DateInvoiceGezien != source.DateInvoiceGezien) { dest.DateInvoiceGezien = source.DateInvoiceGezien; dirty = true; }
        if (dest.EmailGezien != source.EmailGezien) { dest.EmailGezien = source.EmailGezien; dirty = true; }
        if (dest.DateEmailGezien != source.DateEmailGezien) { dest.DateEmailGezien = source.DateEmailGezien; dirty = true; }
        return dirty;
    }
}