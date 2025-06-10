namespace BSD.Business.Converters;

public static class BankStatementInvoiceConverter
{
    public static BSD.Shared.Dtos.BankStatementInvoice ToDto(this BSD.Data.Entities.BankStatementInvoice item)
    {
        var newItem = new BSD.Shared.Dtos.BankStatementInvoice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.BankStatementInvoice ToEntity(this BSD.Shared.Dtos.BankStatementInvoice item)
    {
        var newItem = new BSD.Data.Entities.BankStatementInvoice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.BankStatementInvoice source, BSD.Data.Entities.BankStatementInvoice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.BankStatementId != source.BankStatementId) { dest.BankStatementId = source.BankStatementId; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.BankStatementInvoice source, BSD.Shared.Dtos.BankStatementInvoice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.BankStatementId != source.BankStatementId) { dest.BankStatementId = source.BankStatementId; dirty = true; }
        if (dest.InvoiceId != source.InvoiceId) { dest.InvoiceId = source.InvoiceId; dirty = true; }
        return dirty;
    }
}