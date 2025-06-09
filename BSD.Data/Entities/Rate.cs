using CodeGenerator.Shared.Attributes;
using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class Rate : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public long TaxRateId { get; set; }
    public virtual TaxRate? TaxRate { get; set; }

    [Name]
    [StringLength(255)]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public virtual ICollection<Workorder>? Workorders { get; set; }

    //public double GetTax()
    //{
    //    if (Tax == null)
    //    {
    //        Tax = Price / 100 * (TaxRate == null ? 0 : TaxRate.Percentage);
    //    }
    //    return Tax.Value;
    //}
}
