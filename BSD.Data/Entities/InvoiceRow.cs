using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public long TaxRateId { get; set; }
    public virtual TaxRate? TaxRate { get; set; }

    public double Amount { get; set; }
    public string? Description { get; set; }
    public double PricePerPiece { get; set; }
    public double Price { get; set; }

    public bool IsDiscountRow { get; set; }



    //public double GetTax()
    //{
    //    if (Invoice == null) return 0;
    //    return Price / 100 * (Invoice.TaxRate == null ? 0 : Invoice.TaxRate.Percentage);
    //}
}
