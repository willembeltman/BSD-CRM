using CodeGenerator.Shared.Attributes;
using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceType : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Invoice>? Invoices { get; set; }

}
