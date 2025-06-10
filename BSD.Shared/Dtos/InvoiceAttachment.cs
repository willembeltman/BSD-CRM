using System;


namespace BSD.Shared.Dtos;

public class InvoiceAttachment
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
    public DateTime? Date { get; set; }
    public bool IsInvoicePDF { get; set; }
    public bool IsWorkorderPDF { get; set; }
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    public string? StorageMimeType { get; set; }
    public string StorageFolder { get; set; } = string.Empty;
    public string? StorageFileUrl { get; set; }
}