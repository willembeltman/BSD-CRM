using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long InvoiceId { get; set; }
    public virtual Product? Product { get; set; }
    public long ProductId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public int Amount { get; set; }
}
