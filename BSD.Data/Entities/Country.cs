using CodeGenerator.Shared.Attributes;
using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class Country : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Name]
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public virtual ICollection<Customer>? Customers { get; set; }
    public virtual ICollection<Company>? Companies { get; set; }
    public virtual ICollection<TaxRate>? TaxRates { get; set; }
    public virtual ICollection<Supplier>? Suppliers { get; set; }


}
