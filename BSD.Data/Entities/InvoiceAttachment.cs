using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public DateTime? Date { get; set; }
    public bool IsInvoicePDF { get; set; }
    public bool IsWorkorderPDF { get; set; }

    string IStorageFile.Id => Id.ToString();
}