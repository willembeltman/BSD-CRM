using BSD.Shared;
using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceAttachment : IStorageFile, IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public DateTime? Date { get; set; }
    public bool IsInvoicePDF { get; set; }
    public bool IsWorkorderPDF { get; set; }

    [StringLength(255)]
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    [StringLength(128)]
    public string? StorageMimeType { get; set; }

    [NotMapped]
    public string StorageFolder { get => "InvoiceAttachment"; }

}
