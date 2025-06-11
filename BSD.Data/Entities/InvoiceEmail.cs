using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceEmail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public string? EmailFrom { get; set; }
    public string? EmailTo { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime DateVerzonden { get; set; }
    public bool InvoiceGezien { get; set; }
    public DateTime? DateInvoiceGezien { get; set; }
    public bool EmailGezien { get; set; }
    public DateTime? DateEmailGezien { get; set; }

}
